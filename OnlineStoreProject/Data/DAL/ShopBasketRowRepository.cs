using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class ShopBasketRowRepository : BaseRepository<ShopBasketRow>, IShopBasketRowRepository
    {
        private readonly OnlineStoreContext _context;
        public ShopBasketRowRepository(OnlineStoreContext context) : base(context)
        {
            _context = context;
        }

        public bool ProductExists(int product, int id)
        {
            if (_context.ShopBasketRows.Where(p => p.ProductId == product & p.ShopBasketId == id).Count() > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int ExistingRowId(int product, int id)
        {
            
            return _context.ShopBasketRows.Where(p => p.ProductId == product & p.ShopBasketId == id).FirstOrDefault().Id;
        }

    }
}
