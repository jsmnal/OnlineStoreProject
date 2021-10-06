using Microsoft.AspNetCore.Identity;
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

            // TODO: Create separate configure files to entity classes?
            modelBuilder.Entity<OnlineStoreUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
