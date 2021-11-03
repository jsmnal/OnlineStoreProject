using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(OnlineStoreContext context) : base(context)
        {

        }
    }
}
