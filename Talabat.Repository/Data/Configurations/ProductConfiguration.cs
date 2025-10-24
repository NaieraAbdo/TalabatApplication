﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.ProductBrand)
                .WithMany();
            builder.HasOne(P => P.ProductType)
                .WithMany();
            builder.Property(P => P.Name)
                .IsRequired();
            builder.Property(P => P.Description)
                .IsRequired();
            builder.Property(P => P.PictureUrl)
                .IsRequired();
            builder.Property(P => P.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
