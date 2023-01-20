using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_mvc_pv125.Controllers
{
    public class ProductsController : Controller
    {
        ShopDbContext context = new ShopDbContext();

        public ProductsController()
        {
        }

        public IActionResult Index()
        {
            // get data from db
            return View(context.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest(); // error 400

            // get product by id
            var product = context.Products.Find(id);

            if (product == null) return NotFound(); // error 404

            return View(product);
        }
    }
}
