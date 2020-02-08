using BusinessCore.Areas.General.Models;

namespace BusinessCore.Areas.ShoppingBasket.Services
{
    public interface IScanningService
    {
        Models.ShoppingBasket Scan(string productList);
    }
}