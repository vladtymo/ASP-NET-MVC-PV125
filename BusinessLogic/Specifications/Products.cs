using Ardalis.Specification;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
    public static class Products
    {
        public class OrderedAll : Specification<Product>
        {
            public OrderedAll()
            {
                Query
                    .OrderByDescending(x => x.Name)
                    .Include(x => x.Category);
            }
        }
        public class ByIds : Specification<Product>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Category);
            }
        }
        public class ById : Specification<Product>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Category);
            }
        }
    }
}
