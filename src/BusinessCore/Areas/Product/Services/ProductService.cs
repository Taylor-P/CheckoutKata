using System;
using System.Collections.Generic;
using System.Linq;
using BusinessCore.Areas.Product.Mappers;
using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.Product.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductUoW _productUoW;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductUoW productUoW, ILogger<ProductService> logger)
        {
            _productUoW = productUoW;
            _logger = logger;
        }

        public ICollection<ProductTable> GetListOfAvailableProducts()
        {
            _productUoW.ProductRepository.TryGetAllProducts(out var productTables);

            return productTables.ToList();
        }

        public bool CreateNewProduct(string sku,double price,int discountAmount, double discountPrice)
        {
            if (sku == string.Empty) return false;

            var product = _productUoW.ProductRepository.CreateProduct(sku, price);

            if (discountAmount > 0)
            {
                product.Discount = _productUoW.DiscountFileRepository.CreateDiscount(discountAmount, discountPrice * -1);
            }

            return _productUoW.Save();
        }
    }
}
