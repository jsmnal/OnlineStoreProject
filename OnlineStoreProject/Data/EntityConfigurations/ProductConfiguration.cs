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

            // Seed initial data to table
            builder.HasData(      
                new Product 
                {
                    Id = 1, 
                    Name = "Dog Picture",
                    Description = "Picture of a cute dog",
                    StockQuantity = 12,
                    Price = 19.99M,
                    CreatedDate = new DateTime(2021, 01, 10, 10, 00, 00),
                    ImagePath = "",
                    CategoryId = 1,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 2, 
                    Name = "Cat Picture",
                    Description = "Picture of a not so cute cat",
                    StockQuantity = 25,
                    Price = 12.90M,
                    CreatedDate = new DateTime(2021, 06, 12, 00, 00, 00),
                    ImagePath = "",
                    CategoryId = 1,
                    DiscountId = 2
                },
                new Product 
                {
                    Id = 3, 
                    Name = "Winter forest",
                    Description = "Picture of a beautifull winter forest from Lapland",
                    StockQuantity = 2,
                    Price = 49.99M,
                    CreatedDate = new DateTime(2021, 12, 01, 09, 30, 00),
                    ImagePath = "",
                    CategoryId = 2,
                    DiscountId = 1
                }
                );
            
        }
    }
}
