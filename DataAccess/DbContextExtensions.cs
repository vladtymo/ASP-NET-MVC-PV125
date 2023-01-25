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
                    CategoryId = 1,
                    ImagePath = @"https://itmag.ua/upload/iblock/fbe/65lsmcx1qk329m43h01cqxx2il8ihjq0/12kke.jpg"
                },
                new Product()
                {
                    Id = 2,
                    Name = "iPhone 14 Pro Max",
                    Price = 999,
                    CategoryId = 1,
                    ImagePath = @"https://cdn1.it4profit.com/AfrOrF3gWeDA6VOlDG4TzxMv39O7MXnF4CXpKUwGqRM/resize:fill:540/bg:f6f6f6/q:100/plain/s3://catalog-products/220908083550179270/221010160030013906.png@webp"
                },
                new Product()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Price = 60,
                    CategoryId = 2,
                    ImagePath = @"https://kupytut.com.ua/wp-content/uploads/2022/11/t-shirt-with-logo-1.jpg"
                },
                new Product()
                {
                    Id = 4,
                    Name = "Xiaomi Powerbank",
                    Price = 120,
                    CategoryId = 3,
                    ImagePath = @"https://globus-shop.co.ua/wp-content/uploads/2022/11/11-18-416x416.png"
                },
                new Product()
                {
                    Id = 5,
                    Name = "Apple HomePod Mini",
                    Price = 450,
                    CategoryId = 4,
                    ImagePath = @"https://hotline.ua/img/tx/263/2638898185.jpg"
                }
            });
        }
    }
}