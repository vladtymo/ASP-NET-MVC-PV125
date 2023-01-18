using asp_net_mvc_pv125.Helpers;
using asp_net_mvc_pv125.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_pv125.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products = new List<Product>(Seeder.GetProducts());
        public ProductsController()
        {
        }

        public IActionResult Index()
        {
            // TODO: get data from db

            return View(products);
        }

        public IActionResult Details(int id)
        {
            // get product by id
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            return View(product);
        }
    }
}
