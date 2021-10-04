﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStoreProject.Data.EntityConfigurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(d => d.Name).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(d => d.Description).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(d => d.DiscountPercentage).HasPrecision(10, 2);
        }
    }
}
