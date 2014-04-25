using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class InventoryByProductId : AbstractCriteria<Inventory>
    {
        private int _prodId;

        public InventoryByProductId(int prodId)
        {
            _prodId = prodId;
        }

        public override IQueryable<Inventory> BuildQueryOver(IQueryable<Inventory> queryBase)
        {
            IQueryable<Inventory> inventories = base.BuildQueryOver(queryBase);

            return inventories.Where(s => s.ProductID == _prodId);
        }
    }
}
