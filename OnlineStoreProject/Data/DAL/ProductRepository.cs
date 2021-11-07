using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(OnlineStoreContext context) : base(context)
        {

        }
    }
}
