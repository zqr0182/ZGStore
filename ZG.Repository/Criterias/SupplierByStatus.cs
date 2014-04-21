using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Common;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class SupplierByStatus : AbstractCriteria<Supplier>
    {
        SupplierStatus _supplierStatus;

        public SupplierByStatus(SupplierStatus status)
        {
            _supplierStatus = status;
        }

        public override IQueryable<Supplier> BuildQueryOver(IQueryable<Supplier> queryBase)
        {
            var status = _supplierStatus.ToString();

            return base.BuildQueryOver(queryBase).Where(s => s.Status == status);
        }
    }
}
