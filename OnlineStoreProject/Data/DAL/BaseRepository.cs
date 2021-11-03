using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly OnlineStoreContext _context;
        public BaseRepository(OnlineStoreContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            return entity;

        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
