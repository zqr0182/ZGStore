using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class OrderByActive : AbstractCriteria<Order>
    {
        private bool? _active;

        public OrderByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<Order> BuildQueryOver(IQueryable<Order> queryBase)
        {
            IQueryable<Order> orders = base.BuildQueryOver(queryBase);

            return orders.Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));
        }
    }
}
