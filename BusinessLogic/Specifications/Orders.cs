using Ardalis.Specification;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
    public static class Orders
    {
        public class ByUser : Specification<Order>
        {
            public ByUser(string userId)
            {
                Query.Where(x => x.UserId == userId);
            }
        }
    }
}
