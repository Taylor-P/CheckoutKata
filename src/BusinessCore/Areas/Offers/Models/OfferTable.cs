using BusinessCore.Areas.General.Models;

namespace BusinessCore.Areas.Offers.Models
{
    public class OfferTable : BaseEntity
    {
        public int NumberOfItems { get; set; }
        public double DiscountedAmount { get; set; }
    }
}
