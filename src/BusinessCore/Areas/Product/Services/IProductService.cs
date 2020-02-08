using System.Collections.Generic;
using BusinessCore.Areas.Product.Models;

namespace BusinessCore.Areas.Product.Services
{
    public interface IProductService
    {
        ICollection<ProductTable> GetListOfAvailableProducts();
        bool CreateNewProduct(string sku, double price, int discountAmount, double discountPrice);
    }
}