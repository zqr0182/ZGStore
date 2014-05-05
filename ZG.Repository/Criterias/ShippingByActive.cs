using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ShippingByActive : AbstractCriteria<Shipping>
    {
        private bool? _active;

        public ShippingByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<Shipping> BuildQueryOver(IQueryable<Shipping> queryBase)
        {
            IQueryable<Shipping> shippings = base.BuildQueryOver(queryBase);

            return shippings.Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));
        }
    }
}
