namespace BusinessCore.Areas.ShoppingBasket.Models
{
    public interface IItem
    {
        double PricePerItem { get; set; }
        int Qty { get; set; }
        string Sku { get; set; }

        double Total();
    }
}