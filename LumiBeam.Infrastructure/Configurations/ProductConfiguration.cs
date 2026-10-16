using LumiBeam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumiBeam.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.SKU)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Barcode)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasIndex(p => p.Barcode)
                .IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.RetailPrice)
                .HasPrecision(18, 2);

            builder.Property(p => p.BonusPerUnit)
                .HasPrecision(18, 2);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
