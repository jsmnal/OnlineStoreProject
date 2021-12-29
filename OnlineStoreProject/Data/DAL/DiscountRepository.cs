using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.DAL
{
    public class DiscountRepository : BaseRepository<Discount>, IDiscountRepository
    {
        private readonly OnlineStoreContext _context;
        public DiscountRepository(OnlineStoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Discount> UpdateDiscount(int id, Discount discount)
        {
            var existingDiscount = await _context.Discounts.FindAsync(id);
            if (existingDiscount is not null)
            {
                existingDiscount.Name = discount.Name;
                existingDiscount.Description = discount.Description;
                existingDiscount.DiscountPercentage = discount.DiscountPercentage;
                existingDiscount.ActivityState = discount.ActivityState;
            }
            _context.Entry(existingDiscount).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingDiscount;
        }
    }
}
