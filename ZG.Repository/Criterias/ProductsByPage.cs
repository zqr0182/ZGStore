using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProductsByPage : AbstractCriteria<Product>
    {
        private readonly int _page;
        private readonly int _pageSize;

        public ProductsByPage(int page, int pageSize, ICriteria<Product> initialCriteria = null)
            : base(initialCriteria)
        {
            _page = page;
            _pageSize = pageSize;
        }

        public override IQueryable<Product> BuildQueryOver(IQueryable<Product> queryBase)
        {
            return base.BuildQueryOver(queryBase).OrderBy(p => p.Id).Skip((_page - 1) * _pageSize).Take(_pageSize);
        }
    }
}
