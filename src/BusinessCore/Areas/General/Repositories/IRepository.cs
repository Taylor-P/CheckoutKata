using System.Collections.Generic;
using BusinessCore.Areas.General.Models;

namespace BusinessCore.Areas.General.Repositories
{
    public interface IRepository<T> where  T: BaseEntity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
    }
}
