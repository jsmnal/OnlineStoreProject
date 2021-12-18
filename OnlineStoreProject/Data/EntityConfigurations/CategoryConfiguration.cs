using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(c => c.Description).HasColumnType("nvarchar").HasMaxLength(50);

            // Seed initial data to table
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Animals",
                    Description = "Pictures of different animals"
                },
                new Category
                {
                    Id = 2,
                    Name = "Nature",
                    Description = "Pictures of beatifull nature"
                }
            );
        }
    }
}
