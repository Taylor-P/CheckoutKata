using BusinessCore.Areas.Offers.Models;

namespace BusinessCore.Areas.Offers.Repositories
{
    public interface IOfferRepository
    {
        OfferTable CreateDiscount(int qty, double discount);
    }
}
