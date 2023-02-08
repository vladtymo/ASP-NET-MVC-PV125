using DataAccess;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        //private readonly ShopDbContext context;
        private readonly IRepository<Product> productRepo;
        private readonly IRepository<Category> categoryRepo;

        public ProductsService(IRepository<Product> productRepo,
                               IRepository<Category> categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }

        public void Create(Product product)
        {
            productRepo.Insert(product);
            productRepo.Save();
        }

        public void Delete(int id)
        {
            var product = Get(id);

            if (product == null) return;

            // delete element from db
            productRepo.Delete(product);
            productRepo.Save();
        }

        public void Edit(Product product)
        {
            productRepo.Update(product);
            productRepo.Save();
        }

        public List<Product> GetAll()
        {
            // include properties: LEFT JOIN in SQL
            return productRepo.Get(includeProperties: new[] { "Category" }).ToList();
        }

        public Product? Get(int id)
        {
            if (id < 0) return null; // exception

            // get product by id
            var product = productRepo.GetByID(id);

            //if (product == null) return null; // exception

            return product;
        }

        public List<Category> GetCategories()
        {
            return categoryRepo.Get().ToList();
        }

        public List<Product> Get(int[] ids)
        {
            return productRepo.Get(x => ids.Contains(x.Id)).ToList();
        }
    }
}
