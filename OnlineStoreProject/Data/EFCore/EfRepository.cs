using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.EFCore
{
    public abstract class EfRepository<T, TContext> : IRepository<T> where T : class where TContext : DbContext
    {
        private readonly OnlineStoreContext _context;
        public EfRepository(OnlineStoreContext context)
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
    }
}
