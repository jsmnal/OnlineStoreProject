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
                    ImagePath = "dog.jpeg",
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
                    ImagePath = "cat.jpeg",
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
                    ImagePath = "winter-forest.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 4, 
                    Name = "Lapland",
                    Description = "Picture of a beautifull Lapland",
                    StockQuantity = 27,
                    Price = 99.99M,
                    CreatedDate = new DateTime(2021, 12, 01, 09, 30, 00),
                    ImagePath = "Lappi_1.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 5, 
                    Name = "Lapland mountain",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 19.99M,
                    CreatedDate = new DateTime(2021, 12, 01, 09, 30, 00),
                    ImagePath = "Lappi_2.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 6, 
                    Name = "Lapland forest",
                    Description = "Forest of Finland",
                    StockQuantity = 10,
                    Price = 9.99M,
                    CreatedDate = new DateTime(2021, 12, 01, 09, 30, 00),
                    ImagePath = "Lappi_3.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 7, 
                    Name = "Lapland 1",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 19.99M,
                    CreatedDate = new DateTime(2021, 12, 01, 09, 30, 00),
                    ImagePath = "Lappi_4.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 8, 
                    Name = "Lapland 2",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 19.99M,
                    CreatedDate = new DateTime(2021, 12, 02, 09, 30, 00),
                    ImagePath = "Lappi_5.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 9, 
                    Name = "Lapland 3",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 19.99M,
                    CreatedDate = new DateTime(2021, 12, 04, 09, 30, 00),
                    ImagePath = "Lappi_6.jpg",
                    CategoryId = 2,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 10, 
                    Name = "Lapland 4",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 8.89M,
                    CreatedDate = new DateTime(2021, 11, 02, 09, 30, 00),
                    ImagePath = "Lappi_7.jpg",
                    CategoryId = 3,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 11, 
                    Name = "Lapland 5",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 20.00M,
                    CreatedDate = new DateTime(2021, 11, 01, 09, 30, 00),
                    ImagePath = "Lappi_8.jpg",
                    CategoryId = 3,
                    DiscountId = 1
                },
                new Product 
                {
                    Id = 12, 
                    Name = "Lapland 6",
                    Description = "Mountain of Finland",
                    StockQuantity = 22,
                    Price = 89.99M,
                    CreatedDate = new DateTime(2021, 09, 02, 09, 30, 00),
                    ImagePath = "Lappi_9.jpg",
                    CategoryId = 3,
                    DiscountId = 1
                }
                );
            
        }
    }
}
