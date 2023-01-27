using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_net_mvc_pv125.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext context;

        public ProductsController(ShopDbContext context)
        {
            this.context = context;
        }

        private void LoadCategories()
        {
            // ViewData is nothing but a dictionary of objects and it is accessible by string as key
            // ViewData["List"] = new List<int>() { 1, 2, 3 };

            // ViewBag is a dynamic property (dynamic keyword which is introduced in .net framework 4.0)
            ViewBag.CategoryList = new SelectList(context.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
        }

        // GET: ~/Products/Index
        public IActionResult Index()
        {
            // get data from db
            return View(context.Products.ToList());
        }

        // GET: ~/Products/Details/{id}
        public IActionResult Details(int id)
        {
            if (id < 0) return BadRequest(); // error 400

            // get product by id
            var product = context.Products.Find(id);

            if (product == null) return NotFound(); // error 404

            return View(product);
        }

        // GET: ~/Products/Create
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        // POST: ~/Products/Create
        [HttpPost]
        public IActionResult Create(Product product) // product - model
        {
            // validations
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            // add product to db
            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ~/Products/Edit/{id}
        public IActionResult Edit(int id)
        {
            // get element by id
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            LoadCategories();
            return View(product);
        }

        // POST: ~/Products/Edit
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            // validations
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            // edit product in db
            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ~/Products/Delete/{id}
        public IActionResult Delete(int id)
        {
            // get element by id
            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            // delete element from db
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
