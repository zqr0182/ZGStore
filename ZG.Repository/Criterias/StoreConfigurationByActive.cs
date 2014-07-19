using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class StoreConfigurationByActive : AbstractCriteria<StoreConfiguration>
    {
        private bool? _active;

        public StoreConfigurationByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<StoreConfiguration> BuildQueryOver(IQueryable<StoreConfiguration> queryBase)
        {
            IQueryable<StoreConfiguration> configs = base.BuildQueryOver(queryBase);

            return configs.Where(c => c.Active == (_active.HasValue ? _active.Value : c.Active));
        }
    }
}
