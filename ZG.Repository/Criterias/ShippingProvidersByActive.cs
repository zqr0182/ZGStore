using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ShippingProvidersByActive : AbstractCriteria<ShippingProvider>
    {
        private bool _isActive;

        public ShippingProvidersByActive(bool isActive)
        {
            _isActive = isActive;
        }

        public override IQueryable<ShippingProvider> BuildQueryOver(IQueryable<ShippingProvider> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(s => s.Active == _isActive);
        }
    }
}
