using asp_net_mvc_pv125.Models;

namespace asp_net_mvc_pv125.Helpers
{
    public static class Seeder
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new Product[]
            {
                new Product() 
                {
                    Id = 1,
                    Name = "Google Pixel 7 Pro",
                    Price = 1200,
                    Category = "Electronics"
                },
                new Product()
                {
                    Id = 2,
                    Name = "iPhone 14 Pro",
                    Price = 999,
                    Category = "Electronics"
                },
                new Product()
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Price = 60,
                    Category = "Clothes"
                },
                new Product()
                {
                    Id = 4,
                    Name = "Xiaomi Powerbank",
                    Price = 120,
                    Category = "Accesories"
                },
                new Product()
                {
                    Id = 5,
                    Name = "Apple HomePod Mini",
                    Price = 450,
                    Category = "Home Electronics"
                }
            };
        }
    }
}
