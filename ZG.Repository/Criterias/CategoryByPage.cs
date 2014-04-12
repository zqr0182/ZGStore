using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class CategoryByPage : AbstractCriteria<Category>
    {
        private readonly int _page;
        private readonly int _pageSize;

        public CategoryByPage(int page, int pageSize, ICriteria<Category> initialCriteria = null)
            : base(initialCriteria)
        {
            _page = page;
            _pageSize = pageSize;
        }

        public override IQueryable<Category> BuildQueryOver(IQueryable<Category> queryBase)
        {
            return base.BuildQueryOver(queryBase).OrderBy(c => c.CategoryName).Skip((_page - 1) * _pageSize).Take(_pageSize);
        }
    }
}
