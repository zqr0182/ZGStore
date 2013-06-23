using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class OrderStatusByActive : AbstractCriteria<OrderStatus>
    {
        private bool _isActive;

        public OrderStatusByActive(bool isActive)
        {
            _isActive = isActive;
        }

        public override IQueryable<OrderStatus> BuildQueryOver(IQueryable<OrderStatus> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(s => s.Active == _isActive);
        }
    }
}
