using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public interface IProductsService
    {
        List<Category> GetCategories();
        List<Product> GetAll();
        Product? GetById(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);
    }

    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext context;

        public ProductsService(ShopDbContext context)
        {
            this.context = context;
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetById(id);

            if (product == null) return;

            // delete element from db
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public void Edit(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            if (id < 0) return null; // exception

            // get product by id
            var product = context.Products.Find(id);

            //if (product == null) return null; // exception

            return product;
        }

        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
    }
}
