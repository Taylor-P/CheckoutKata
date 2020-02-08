using BusinessCore.Areas.General.UnitOfWorks;
using BusinessCore.Areas.Offers.Repositories;
using BusinessCore.Areas.Product.Repositories;

namespace BusinessCore.Areas.Product.UnitOfWorks
{
    public interface IProductUoW : IUoW
    {
        IProductRepository ProductRepository { get; }
        IOfferRepository DiscountFileRepository { get; }
    }
}
