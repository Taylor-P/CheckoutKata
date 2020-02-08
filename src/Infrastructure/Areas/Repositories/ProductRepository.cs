using System.Collections.Generic;
using System.Linq;
using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.Product.Repositories;
using Infrastructure.Areas.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Areas.Repositories
{
    public class ProductRepository : Repository<ProductTable>, IProductRepository
    {
        public ProductRepository(CheckoutContext context) : base(context)
        {
        }

        public bool TryGetAllProducts(out ICollection<ProductTable> products)
        {
            products = DbSet
                .Include(p => p.Discount) 
                .ToList();
            return products.Count > 0;
        }

        public bool TryGetProductsBySkus(string[] skus, out ICollection<ProductTable> products)
        {
            products = DbSet
                .Where(p => skus.Contains(p.Sku))
                .ToList();
            return products.Count > 0;
        }

        public bool TryGetProductBySku(string sku, out ProductTable product)
        {
            product = DbSet
                .Where(p => p.Sku == sku).
                ToList().
                FirstOrDefault();
            return product != null;
        }

        public ProductTable CreateProduct( string sku, double price)
        {
            var product = new ProductTable
            {
                Sku = sku,
                Price = price
            };

            Add(product);
            return product;
        }
    }
}
