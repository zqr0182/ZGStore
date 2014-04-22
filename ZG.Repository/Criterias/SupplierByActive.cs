using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class SupplierByActive : AbstractCriteria<Supplier>
    {
        bool _active;
        public SupplierByActive(bool active)
        {
            _active = active;
        }

        public override IQueryable<Supplier> BuildQueryOver(IQueryable<Supplier> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(s => s.Active == _active);
        }
    }
}
