using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class ShopBasketRepository : BaseRepository<ShopBasket>
    {
        public ShopBasketRepository(OnlineStoreContext context) : base(context)
        {

        }
    }
}
