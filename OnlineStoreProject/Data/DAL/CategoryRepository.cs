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

    }
}
