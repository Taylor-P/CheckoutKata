using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.ShoppingBasket.Models;
using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.Product.Mappers
{
    public class ProductMapper : IProductMapper
    {
        private readonly ILogger<ProductMapper> _logger;

        public ProductMapper(ILogger<ProductMapper> logger)
        {
            _logger = logger;
        }

        public IItem ProductTableToItem(ProductTable productTable)
        {
            var item = new Item()
            {
                Sku = productTable.Sku,
                PricePerItem = productTable.Price,
                Qty = 0
            };

            return item;
        }
    }
}
