using System.Collections.Generic;
using System.Linq;

namespace BusinessCore.Areas.ShoppingBasket.Models
{
    public class ShoppingBasket : IShoppingBasket
    {

        public ShoppingBasket()
        {
            Items = new List<IItem>();
            Discounts = new List<IDiscount>();
        }

        public ICollection<IItem> Items { get; set; }
        public ICollection<IDiscount> Discounts { get; set; }

        public double TotalDiscountCost()
        {
            return Discounts.Aggregate<IDiscount, double>(0, (current, offer) => current + offer.TotalOfferPrice());
        }

        public double TotalItemsCost()
        {
            return Items.Aggregate<IItem, double>(0, (current, item) => current +  item.Total());
        }

        public double TotalCost()
        {
            return TotalItemsCost() + TotalDiscountCost();
        }
    }
}
