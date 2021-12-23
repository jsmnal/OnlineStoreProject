using Microsoft.EntityFrameworkCore;
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

        public bool ProductExists(int productId, int shopBasketId)
        {
            if (_context.ShopBasketRows.Where(s => s.ProductId == productId & s.ShopBasketId == shopBasketId).Count() > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public int GetSBRowId(int productId, int shopBasketId)
        {
            
            return _context.ShopBasketRows.Where(s => s.ProductId == productId & s.ShopBasketId == shopBasketId).FirstOrDefault().Id;
        }

        public async Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId(int shopBasketId)
        {
            return await _context.ShopBasketRows.Where(s => s.ShopBasketId == shopBasketId).ToArrayAsync();
        }
    }
}
