using BusinessCore.Areas.General.UnitOfWorks;
using Infrastructure.Areas.Database;

namespace Infrastructure.Areas.UnitOfWorks
{
    public class UoW : IUoW
    {
        protected readonly CheckoutContext Context;

        public UoW(CheckoutContext context)
        {
            Context = context;
        }

        public bool Save()
        {
            return Context.SaveChanges() > 0;
        }
    }
}
