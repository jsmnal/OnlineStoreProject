using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.ServiceLayer.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> Get(int id);
        Task<Category> Delete(int id);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetWithName(string name);

        Task<Category> UpdateCategory(int id, Category category);
    }
}
