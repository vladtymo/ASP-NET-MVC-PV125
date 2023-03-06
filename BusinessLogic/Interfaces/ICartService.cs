using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ICartService
    {
        List<ProductDto> GetProducts();
        void Add(int productId);
        void Remove(int productId);
        bool IsInCart(int productId);
    }
}
