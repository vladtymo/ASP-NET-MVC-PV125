using DataAccess.Configurations;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

            modelBuilder.ApplyConfiguration(new ProductConfigurations());
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string connStr = @"workstation id=pvd125shop.mssql.somee.com;packet size=4096;user id=wladnaz_SQLLogin_1;pwd=qsyiy5d3ff;data source=pvd125shop.mssql.somee.com;persist security info=False;initial catalog=pvd125shop";
        //    optionsBuilder.UseSqlServer(connStr);
        //}

        // ---------------- Data Collections ----------------
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}