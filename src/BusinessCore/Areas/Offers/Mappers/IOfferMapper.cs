using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.ShoppingBasket.Models;

namespace BusinessCore.Areas.Offers.Mappers
{
    public interface IOfferMapper
    {
        string MapOfferText(ProductTable productTable);
        Discount MapToDiscount(ProductTable productTable);
    }
}