using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DbContextExtensions
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() { Id = 1, Name = "Electronics" },
                new Category() { Id = 2, Name = "Clothes" },
                new Category() { Id = 3, Name = "Accesories" },
                new Category() { Id = 4, Name = "Accoustic System" }
            });
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
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
    }
}