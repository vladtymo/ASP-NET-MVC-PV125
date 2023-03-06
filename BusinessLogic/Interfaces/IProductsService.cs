using Core.DTOs;
using Core.Entities;

namespace Core.Services
{
    public interface IProductsService
    {
        List<Category> GetCategories();
        List<ProductDto> GetAll();
        List<ProductDto> Get(int[] ids);
        ProductDto? Get(int id);
        void Create(CreateProductDto product);
        void Edit(ProductDto product);
        void Delete(int id);
    }
}
