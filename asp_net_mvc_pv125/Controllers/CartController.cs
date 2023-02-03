using BusinessLogic.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace asp_net_mvc_pv125.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsService productsService;

        public CartController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            var productId = HttpContext.Session.GetObject<int?>("cart");

            Product product = null;
            if (productId != null)
            {
                product = productsService.GetById(productId.Value);
            }

            return View(product);
        }

        public IActionResult Add(int productId, string returnUrl)
        {
            HttpContext.Session.SetObject("cart", productId);

            return Redirect(returnUrl);
        }
    }
}
