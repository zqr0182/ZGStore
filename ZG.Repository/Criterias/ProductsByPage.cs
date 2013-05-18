using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProductsByPage : ICriteria<Product>
    {
        private readonly int _page;
        private readonly int _pageSize;

        public ZGStoreContext Context { get; set; }

        public ProductsByPage(int page, int pageSize)
        {
            _page = page;
            _pageSize = pageSize;
        }

        public IQueryable<Product> BuildQueryOver(IQueryable<Product> queryBase)
        {
            return queryBase.OrderBy(p => p.Id).Skip((_page - 1) * _pageSize).Take(_pageSize);
        }
    }
}
