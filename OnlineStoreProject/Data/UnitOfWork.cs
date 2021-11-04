using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data
{
    public class UnitOfWork
    {
        private readonly OnlineStoreContext _context;
        private BaseRepository<Category> _categoryRepository;

        public UnitOfWork(OnlineStoreContext context)
        {
            _context = context;
        }

        public BaseRepository<Category> CategoryRepository
        {
            get
            {
                _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
                return _categoryRepository;
            }
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

    }

}
