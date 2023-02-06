using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
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
            var product = Get(id);

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

        public Product? Get(int id)
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

        public List<Product> Get(int[] ids)
        {
            return context.Products.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
