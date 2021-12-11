using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetNewest(int limit);
        Task<IEnumerable<Product>> GetPopular(int limit);
        Task<IEnumerable<Product>> GetWithCategory(string name);
    }
}
