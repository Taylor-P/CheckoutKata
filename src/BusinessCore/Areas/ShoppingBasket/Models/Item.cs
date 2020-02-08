using Microsoft.Extensions.Logging;

namespace BusinessCore.Areas.ShoppingBasket.Models
{
    public class Item : IItem
    {
        public int Qty { get; set; }
        public string Sku { get; set; }
        public double PricePerItem { get; set; }
        public double Total()
        {
            return Qty * PricePerItem;
        }
    }
}
