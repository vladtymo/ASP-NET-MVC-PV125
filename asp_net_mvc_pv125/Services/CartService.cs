using BusinessLogic;
using BusinessLogic.Services;
using DataAccess.Entities;

namespace asp_net_mvc_pv125.Services
{
    public class CartService : ICartService
    {
        private readonly IProductsService productsService;
        private readonly HttpContext? httpContext;

        public CartService(IProductsService productsService,
                           IHttpContextAccessor httpContextAccessor)
        {
            this.productsService = productsService;
            this.httpContext = httpContextAccessor.HttpContext;
        }

        public List<Product> GetProducts()
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            List<Product> products = new List<Product>();

            if (productIds != null)
                products = productsService.Get(productIds.ToArray());

            return products;
        }

        public void Add(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            if (productIds == null) productIds = new List<int>();
            productIds.Add(productId);

            httpContext.Session.SetObject("cart", productIds);
        }

        public void Remove(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");

            if (productIds == null) productIds = new List<int>();
            productIds.Remove(productId);

            httpContext.Session.SetObject("cart", productIds);
        }

        public bool IsInCart(int productId)
        {
            var productIds = httpContext.Session.GetObject<List<int>>("cart");
            return productIds.Contains(productId);
        }
    }
}
