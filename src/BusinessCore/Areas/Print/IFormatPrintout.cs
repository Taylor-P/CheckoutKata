using System.Collections.Generic;
using BusinessCore.Areas.Product.Models;

namespace BusinessCore.Areas.Print
{
    public interface IFormatPrintout
    {
        string PrintAvailableProducts(ICollection<ProductTable> products);
        string PrintReceipt(ShoppingBasket.Models.ShoppingBasket shoppingBasket);
    }
}