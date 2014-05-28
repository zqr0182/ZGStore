using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class OrdersByPage : AbstractCriteria<Order>
    {
        private readonly int _page;
        private readonly int _pageSize;

        public OrdersByPage(int page, int pageSize, ICriteria<Order> initialCriteria = null)
            : base(initialCriteria)
        {
            _page = page;
            _pageSize = pageSize;
        }

        public override IQueryable<Order> BuildQueryOver(IQueryable<Order> queryBase)
        {
            return base.BuildQueryOver(queryBase).OrderBy(p => p.Id).Skip((_page - 1) * _pageSize).Take(_pageSize);
        }
    }
}
