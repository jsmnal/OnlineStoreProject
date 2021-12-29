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
            return _context.ShopBasketRows.Where(s => s.ProductId == productId & s.ShopBasketId == shopBasketId).Any() ? true : false;
        }

        public int GetSBRowId(int productId, int shopBasketId)
        {
            
            return _context.ShopBasketRows.Where(s => s.ProductId == productId & s.ShopBasketId == shopBasketId).FirstOrDefault().Id;
        }

        public async Task<IEnumerable<ShopBasketRow>> GetWithShopBasketId(int shopBasketId)
        {
            return await _context.ShopBasketRows.Where(s => s.ShopBasketId == shopBasketId).ToArrayAsync();
        }

        public async Task<ShopBasketRow> UpdateShopBasketRow(int id, ShopBasketRow shopBasketRow)
        {
            var existingShopBasketRow = await _context.ShopBasketRows.FindAsync(id);
            if(existingShopBasketRow is not null)
            {
                existingShopBasketRow.Quantity = shopBasketRow.Quantity;
                existingShopBasketRow.ProductId = shopBasketRow.ProductId;
                existingShopBasketRow.ShopBasketId = shopBasketRow.ShopBasketId;
            }
            _context.Entry(existingShopBasketRow).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingShopBasketRow;
        }
    }
}
