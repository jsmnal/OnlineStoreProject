using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Data.EntityConfigurations;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data
{
    public class OnlineStoreContext : IdentityDbContext<OnlineStoreUser>
    {
        public OnlineStoreContext( DbContextOptions<OnlineStoreContext> options) : base(options)
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopBasket> ShopBaskets { get; set; }
        public DbSet<ShopBasketRow> ShopBasketRows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DiscountConfiguration())
                .ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new ShopBasketConfiguration())
                .ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
