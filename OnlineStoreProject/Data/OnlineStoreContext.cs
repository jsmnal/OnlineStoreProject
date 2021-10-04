using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopBasket> ShopBaskets { get; set; }
        public DbSet<ShopBasketRow> ShopBasketRows { get; set; }
    }
}
