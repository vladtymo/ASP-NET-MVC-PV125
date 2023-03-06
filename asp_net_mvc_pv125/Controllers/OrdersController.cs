using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_net_mvc_pv125.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly IMailService mailService;

        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string Username => User.FindFirstValue(ClaimTypes.Name);

        public OrdersController(IOrdersService ordersService, IMailService mailService)
        {
            this.ordersService = ordersService;
            this.mailService = mailService;
        }

        public IActionResult Index()
        {
            return View(ordersService.GetAll(UserId));
        }
       
        public IActionResult Create()
        {
            ordersService.Create(UserId);

            // send message
            mailService.SendMailAsync("Order confirmation", "<h2 style='color: darkcyan;'>Order information</h2><p>Order was successfully confirmed!</p>", Username);

            return RedirectToAction(nameof(Index));
        }
    }
}
