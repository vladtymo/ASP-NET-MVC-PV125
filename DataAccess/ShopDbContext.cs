using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataAccess
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base() { }
        public ShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------- Data Initialisation -----------
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
            //DbContextExtensions.SeedCategories(modelBuilder);
            //DbContextExtensions.SeedProducts(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PV125_SHOP_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    optionsBuilder.UseSqlServer(connStr);
        //}

        // ---------------- Data Collections ----------------
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}