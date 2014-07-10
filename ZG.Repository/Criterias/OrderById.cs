using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class OrderById : AbstractCriteria<Order>
    {
        private int _id;

        public OrderById(int id)
        {
            _id = id;
        }

        public override IQueryable<Order> BuildQueryOver(IQueryable<Order> queryBase)
        {
            IQueryable<Order> orders = base.BuildQueryOver(queryBase);

            return orders.Where(o => o.Id == _id);
        }
    }
}
