using LumiBeam.Domain.Entities;
using LumiBeam.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LumiBeam.Infrastructure.Configurations
{
    public class StoreTaskConfiguration : IEntityTypeConfiguration<StoreTask>
    {
        public void Configure(EntityTypeBuilder<StoreTask> builder)
        {
            builder.ToTable("StoreTasks");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property("Description")
                .HasMaxLength(1000);

            builder.Property(t => t.DueDate)
                .HasColumnType("smalldatetime")
                .IsRequired(false);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(t => t.Priority)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(t => t.CreatedBy)
                .WithMany()
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedToUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
