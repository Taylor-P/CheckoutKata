using System.Collections.Generic;
using System.Linq;
using BusinessCore.Areas.Offers.Mappers;
using BusinessCore.Areas.Product.Mappers;
using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.Product.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.ShoppingBasket.Services
{
    public class ScanningService : IScanningService
    {
        private readonly IProductUoW _productUoW;
        private readonly IProductMapper _productMapper;
        private readonly IOfferMapper _discountMapper;
        private readonly ILogger<ScanningService> _logger;

        public ScanningService(IProductUoW productUoW, IProductMapper productMapper, IOfferMapper discountMapper, ILogger<ScanningService> logger)
        {
            _productUoW = productUoW;
            _productMapper = productMapper;
            _discountMapper = discountMapper;
            _logger = logger;
        }

        public Models.ShoppingBasket Scan(string productList)
        {
            return _productUoW.ProductRepository.TryGetProductsBySkus(productList.Split(','), out var productTables)
                ? PopulateDiscounts(productList,PopulateItems(productList, productTables),productTables)
                : null;
        }

        private Models.ShoppingBasket PopulateDiscounts(string productList, Models.ShoppingBasket shoppingBasket , IEnumerable<ProductTable> productTables)
        {

            foreach (var productTable in productTables)
            {
                if (productTable.Discount == null) continue;

                var discount = _discountMapper.MapToDiscount(productTable);

                if (discount == null) continue;
                discount.Qty = productList.Count(p => p == productTable.Sku.ToCharArray()[0]) /
                               productTable.Discount.NumberOfItems;

                if (discount.Qty > 0)
                    shoppingBasket.Discounts.Add(discount);
            }

            return shoppingBasket;
        }

        private Models.ShoppingBasket PopulateItems(string productList, IEnumerable<ProductTable> productTables)
        {
            var shoppingBasket = new Models.ShoppingBasket();

            foreach (var productTable in productTables)
            {
                var item = _productMapper.ProductTableToItem(productTable);

                item.Qty = productList.Count(p => p == productTable.Sku.ToCharArray()[0]);

                shoppingBasket.Items.Add(item);
            }

            return shoppingBasket;
        }
    }
}
