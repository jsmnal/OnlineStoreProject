using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer.Interfaces
{
    public interface IProductService
    {
        Task<Product> Get(int id);
        Task<Product> Delete(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetNewest(int limit);
        Task<IEnumerable<Product>> GetPopular(int limit);
        Task<IEnumerable<Product>> GetWithCategory(string name);
        Task<Product> UpdateProduct(int id, Product product);
    }
}
