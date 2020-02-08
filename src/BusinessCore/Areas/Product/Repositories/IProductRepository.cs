using System.Collections.Generic;
using BusinessCore.Areas.Product.Models;

namespace BusinessCore.Areas.Product.Repositories
{
    public interface IProductRepository 
    {
        bool TryGetAllProducts(out ICollection<ProductTable> products);
        bool TryGetProductsBySkus(string[] skus, out ICollection<ProductTable> products);
        bool TryGetProductBySku(string sku, out ProductTable product);
        ProductTable CreateProduct(string sku, double price);
    }
}
