using BusinessLogic;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_net_mvc_pv125.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View(ordersService.GetAll(UserId));
        }

        public IActionResult Create()
        {
            ordersService.Create(UserId);
            return RedirectToAction(nameof(Index));
        }
    }
}
