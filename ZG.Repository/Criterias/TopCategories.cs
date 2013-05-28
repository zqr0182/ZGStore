using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class TopCategories : AbstractCriteria<Category>
    {
        private readonly bool _activeOnly;

        public TopCategories(bool activeOnly)
        {
            _activeOnly = activeOnly;
        }

        public override IQueryable<Category> BuildQueryOver(IQueryable<Category> queryBase)
        {
            return base.BuildQueryOver(queryBase).Where(c => c.Active == _activeOnly && !c.ParentCategoryID.HasValue).OrderBy(c => c.CategoryName);
        }
    }
}
