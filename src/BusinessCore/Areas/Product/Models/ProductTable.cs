using BusinessCore.Areas.General.Models;
using BusinessCore.Areas.Offers.Models;

namespace BusinessCore.Areas.Product.Models
{
    public class ProductTable : BaseEntity
    {
        public string Sku { get; set; }
        public double Price { get; set; }
        public OfferTable Discount { get; set; }
    }
}
