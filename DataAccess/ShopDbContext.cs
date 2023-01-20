using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------- Data Initialisation -----------
            modelBuilder.Entity<Category>().HasData(new[] 
            {
                new Category() { Id = 1, Name = "Electronics" },
                new Category() { Id = 2, Name = "Clothes" },
                new Category() { Id = 3, Name = "Accesories" },
                new Category() { Id = 4, Name = "Accoustic System" }
            });
            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Google Pixel 7 Pro",
                    Price = 1200,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "iPhone 14 Pro",
                    Price = 999,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Price = 60,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 4,
                    Name = "Xiaomi Powerbank",
                    Price = 120,
                    CategoryId = 3
                },
                new Product()
                {
                    Id = 5,
                    Name = "Apple HomePod Mini",
                    Price = 450,
                    CategoryId = 4
                }
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PV125_SHOP_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(connStr);
        }

        // ---------------- Data Collections ----------------
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}