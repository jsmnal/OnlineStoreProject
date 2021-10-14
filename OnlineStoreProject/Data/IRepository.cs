using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data
{
    public interface IRepository<T> where T: class
    {
        Task<T> Get(int Id);
        Task<T> Delete(int Id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
    }
}
