using System;
using System.Collections.Generic;
using System.Text;
using BusinessCore.Areas.Offers.Repositories;
using BusinessCore.Areas.Product.Repositories;
using BusinessCore.Areas.Product.UnitOfWorks;
using Infrastructure.Areas.Database;
using Infrastructure.Areas.Repositories;

namespace Infrastructure.Areas.UnitOfWorks
{
    public class ProductUoW : UoW, IProductUoW
    {
        public ProductUoW(CheckoutContext context) : base(context)
        {
            ProductRepository = new ProductRepository(context);
            DiscountFileRepository = new OfferRepository(context);
        }

        public IProductRepository ProductRepository { get; }
        public IOfferRepository DiscountFileRepository { get; }
    }
}
