using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using MailKit;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> orderRepo;
        private readonly ICartService cartService;

        public OrdersService(IRepository<Order> orderRepo,
                             ICartService cartService)
        {
            this.orderRepo = orderRepo;
            this.cartService = cartService;
        }
        public void Create(string userId)
        {
            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Total = cartService.GetProducts().Sum(x => x.Price)
            };

            orderRepo.Insert(order);
            orderRepo.Save();
        }

        public IEnumerable<Order> GetAll(string userId)
        {
            return orderRepo.GetListBySpec(new Orders.ByUser(userId));
        }
    }
}
