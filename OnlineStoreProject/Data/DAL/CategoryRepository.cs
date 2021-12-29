using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineStoreProject.Data.DAL
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly OnlineStoreContext _context;
        public CategoryRepository(OnlineStoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetWithName(string name)
        {
            return await _context.Categorys.Where(c => c.Name.Contains(name)).ToArrayAsync();
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var existingCategory = await _context.Categorys.FindAsync(id);
            if (existingCategory is not null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
            _context.Entry(existingCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingCategory;
        }

    }
}
