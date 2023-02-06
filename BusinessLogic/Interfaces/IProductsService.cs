using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public interface IProductsService
    {
        List<Category> GetCategories();
        List<Product> GetAll();
        List<Product> Get(int[] ids);
        Product? Get(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(int id);
    }
}
