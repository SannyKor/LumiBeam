using LumiBeam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LumiBeam.Infrastructure
{
    public class LumiBeamDbContext : DbContext
    {
        public LumiBeamDbContext(DbContextOptions<LumiBeamDbContext> options)
        : base(options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<SaleRecord> SaleRecords => Set<SaleRecord>();
        public DbSet<StoreTask> StoreTasks => Set<StoreTask>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
