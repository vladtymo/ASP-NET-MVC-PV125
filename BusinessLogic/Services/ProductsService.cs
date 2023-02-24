using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
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
        private readonly IFileService fileService;

        public ProductsService(IRepository<Product> productRepo,
                               IRepository<Category> categoryRepo,
                               IFileService fileService)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
            this.fileService = fileService;
        }

        public void Create(ProductDto product)
        {
            // save image to the server
            string imagePath = fileService.SaveProductImage(product.Image);

            productRepo.Insert(new Product()
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImagePath = imagePath
            });
            productRepo.Save();
        }

        public void Delete(int id)
        {
            var product = Get(id);

            if (product == null) return;

            // delete image from the server: fileService.DeleteProductImage()

            // delete element from db
            productRepo.Delete(product);
            productRepo.Save();
        }

        public void Edit(Product product)
        {
            // delete old image from the server: fileService.DeleteProductImage()
            // save new image to the server: fileService.SaveProductImage()

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
