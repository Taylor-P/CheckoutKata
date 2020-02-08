using BusinessCore.Areas.Offers.Models;
using BusinessCore.Areas.Offers.Repositories;
using Infrastructure.Areas.Database;

namespace Infrastructure.Areas.Repositories
{
    public class OfferRepository : Repository<OfferTable>, IOfferRepository
    {
        public OfferRepository(CheckoutContext context) : base(context)
        {
        }

        public OfferTable CreateDiscount(int qty, double discount)
        {
            var discounttable = new OfferTable
            {
                DiscountedAmount = discount,
                NumberOfItems = qty
            };

            Add(discounttable);
            return discounttable;
        }
    }
}
