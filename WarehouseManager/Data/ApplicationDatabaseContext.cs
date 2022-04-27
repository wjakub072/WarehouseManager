using Microsoft.EntityFrameworkCore;
using WarehouseManager.Models;

namespace WarehouseManager.Data
{
    internal class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Document> Deliveries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Element> Elements { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Sector> Sectors{ get; set; }
        public DbSet<Warehouse> Warehouses{ get; set; }
        public DbSet<Availability> Availabilities { get; set; }


    }
}
