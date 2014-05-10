using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class TaxByActive : AbstractCriteria<Tax>
    {
        private bool? _active;

        public TaxByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<Tax> BuildQueryOver(IQueryable<Tax> queryBase)
        {
            IQueryable<Tax> taxes = base.BuildQueryOver(queryBase);

            return taxes.Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));
        }
    }
}
