namespace BusinessCore.Areas.ShoppingBasket.Models
{
    public interface IDiscount
    {
        string OfferText { get; set; }
        double PricePerOffer { get; set; }
        int Qty { get; set; }
        string Sku { get; set; }

        double TotalOfferPrice();
    }
}