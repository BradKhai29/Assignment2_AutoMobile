using BusinessObject;
using DataAccess.Database.ModelConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStoreWinApp.Database
{
    public class AppDbContext : DbContext
    {
        private readonly string ConnectionString;

        public AppDbContext(string connectionString) => ConnectionString = connectionString;

        #region DbSet
        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(p => p.IsAvailable)
                        .HasDefaultValue(true);

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }
    }
}
