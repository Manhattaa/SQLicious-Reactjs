using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Model;
using System.Collections.Generic;

namespace SQLicious.Server.Data
{
    public class RestaurantContext : IdentityDbContext<Admin>
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<MenuItems> MenuItems { get; set; }
        public DbSet<MenuPDF> MenuPDFs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for the Table table
            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, Capacity = 6, IsAvailable = true },
                new Table { TableId = 2, Capacity = 6, IsAvailable = true },
                new Table { TableId = 3, Capacity = 4, IsAvailable = true },
                new Table { TableId = 4, Capacity = 4, IsAvailable = true },
                new Table { TableId = 5, Capacity = 4, IsAvailable = true },
                new Table { TableId = 6, Capacity = 4, IsAvailable = true },
                new Table { TableId = 7, Capacity = 4, IsAvailable = true },
                new Table { TableId = 8, Capacity = 4, IsAvailable = true },
                new Table { TableId = 9, Capacity = 4, IsAvailable = true },
                new Table { TableId = 10, Capacity = 4, IsAvailable = true },
                new Table { TableId = 11, Capacity = 4, IsAvailable = true },
                new Table { TableId = 12, Capacity = 8, IsAvailable = true },
                new Table { TableId = 13, Capacity = 8, IsAvailable = true },
                new Table { TableId = 14, Capacity = 8, IsAvailable = true }
            );
        }
    }
}