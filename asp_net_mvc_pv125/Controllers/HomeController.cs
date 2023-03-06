using asp_net_mvc_pv125.Models;
using Core.Services;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp_net_mvc_pv125.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public IActionResult Index()
        {
            // code...

            // View search pattern: ~/Views/{ControllerName}/{ActionName}
            // Current view path: ~Views/Home/Index.cshtml
            return View(productsService.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}