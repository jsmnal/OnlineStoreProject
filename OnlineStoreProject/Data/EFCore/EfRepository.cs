using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.EFCore
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly OnlineStoreContext context;
        public EfRepository(OnlineStoreContext context)
        {
            this.context = context;
        }
        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<T> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
