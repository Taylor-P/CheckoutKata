using System.Collections.Generic;

namespace BusinessCore.Areas.ShoppingBasket.Models
{
    public interface IShoppingBasket
    {
        ICollection<IItem> Items { get; set; }
        ICollection<IDiscount> Discounts { get; set; }

        double TotalCost();
        double TotalDiscountCost();
        double TotalItemsCost();
    }
}