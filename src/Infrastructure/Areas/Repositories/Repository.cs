using BusinessCore.Areas.General.Models;
using Infrastructure.Areas.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Areas.Repositories
{
    public  class Repository<T> where T : BaseEntity //, IRepository<T>
    {
        protected readonly CheckoutContext DbContext;
        protected readonly DbSet<T> DbSet;

        protected Repository(CheckoutContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T FindById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
