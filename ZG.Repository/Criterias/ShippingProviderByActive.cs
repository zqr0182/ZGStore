using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ShippingProviderByActive : AbstractCriteria<ShippingProvider>
    {
        bool _active;
        public ShippingProviderByActive(bool active)
        {
            _active = active;
        }

        public override IQueryable<ShippingProvider> BuildQueryOver(IQueryable<ShippingProvider> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(s => s.Active == _active);
        }
    }
}
