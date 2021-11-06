using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class ShopBasketRowRepository : BaseRepository<ShopBasketRow>
    {
        public ShopBasketRowRepository(OnlineStoreContext context) : base(context)
        {

        }
    }
}
