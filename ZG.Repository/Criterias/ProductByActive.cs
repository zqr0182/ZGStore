using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProductByActive : AbstractCriteria<Product>
    {
        private bool? _active;

        public ProductByActive(bool? active)
        {
            _active = active;
        }

        public override IQueryable<Product> BuildQueryOver(IQueryable<Product> queryBase)
        {
            IQueryable<Product> products = base.BuildQueryOver(queryBase);

            return products.Where(s => s.Active == (_active.HasValue ? _active.Value : s.Active));
        }
    }
}
