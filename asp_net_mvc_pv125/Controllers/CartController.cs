using asp_net_mvc_pv125.Services;
using BusinessLogic;
using BusinessLogic.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace asp_net_mvc_pv125.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            return View(cartService.GetProducts());
        }

        public IActionResult Add(int productId, string returnUrl)
        {
            cartService.Add(productId);
            return Redirect(returnUrl);
        }

        public IActionResult Remove(int productId, string returnUrl)
        {
            cartService.Remove(productId);
            return Redirect(returnUrl);
        }
    }
}
