using LumiBeam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumiBeam.Infrastructure.Configurations
{
    public class SaleRecordConfiguration : IEntityTypeConfiguration<SaleRecord>
    {
        public void Configure(EntityTypeBuilder<SaleRecord> builder)
        {
            builder.ToTable("SaleRecords");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Quantity)
                .IsRequired();

            builder.Property(s => s.UnitPriceSnapshot)
                .HasPrecision(18, 2);

            builder.Property(s => s.BonusPerUnitSnapshot)
                .HasPrecision(18, 2);

            builder.HasOne(s => s.Product)
                .WithMany(p => p.SaleRecords)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.User)
                .WithMany(u => u.SaleRecords)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
