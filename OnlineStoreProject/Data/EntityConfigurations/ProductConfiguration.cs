using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(p => p.Description).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.ImagePath).HasColumnType("nvarchar").HasMaxLength(200);
        }
    }
}
