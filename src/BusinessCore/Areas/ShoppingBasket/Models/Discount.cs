namespace BusinessCore.Areas.ShoppingBasket.Models
{
    public class Discount : IDiscount
    {
        public int Qty { get; set; }
        public string Sku { get; set; }
        public double PricePerOffer { get; set; }
        public string OfferText { get; set; }

        public double TotalOfferPrice()
        {
            return Qty * PricePerOffer;
        }
    }
}
