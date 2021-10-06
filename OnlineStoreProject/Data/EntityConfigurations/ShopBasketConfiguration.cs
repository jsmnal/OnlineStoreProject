using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.EntityConfigurations
{
    public class ShopBasketConfiguration : IEntityTypeConfiguration<ShopBasket>
    {
        public void Configure(EntityTypeBuilder<ShopBasket> builder)
        {
            builder.Property(s => s.Total).HasPrecision(10, 2);
        }
    }
}
