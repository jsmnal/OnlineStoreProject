using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class ShopBasketRepository : BaseRepository<ShopBasket>, IShopBasketRepository
    {
        private readonly OnlineStoreContext _context;
        public ShopBasketRepository(OnlineStoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ShopBasket> UpdateShopBasket(int id, ShopBasket shopBasket)
        {
            var existingShopBasket = await _context.ShopBaskets.FindAsync(id);
            if (existingShopBasket is not null)
            {
                existingShopBasket.Total = shopBasket.Total;
                existingShopBasket.Updated = shopBasket.Updated;
                existingShopBasket.SentOrder = shopBasket.SentOrder;
                existingShopBasket.UserId = shopBasket.UserId;
            }
            _context.Entry(existingShopBasket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingShopBasket;
        }
    }
}
