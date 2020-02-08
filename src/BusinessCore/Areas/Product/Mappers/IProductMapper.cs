using BusinessCore.Areas.Product.Models;
using BusinessCore.Areas.ShoppingBasket.Models;

namespace BusinessCore.Areas.Product.Mappers
{
    public interface IProductMapper
    {
        //General.Models.Product ProductTableToProduct(ProductTable productTable);
        IItem ProductTableToItem(ProductTable productTable);

    }
}