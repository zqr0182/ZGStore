using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class CategoryByActive : AbstractCriteria<Category>
    {
        private bool _activeOnly;

        public CategoryByActive(bool activeOnly)
        {
            _activeOnly = activeOnly;
        }

        public override IQueryable<Category> BuildQueryOver(IQueryable<Category> queryBase)
        {
            IQueryable<Category> categories = base.BuildQueryOver(queryBase);

            if (_activeOnly)
            {
                categories = categories.Where(s => (s.Active));
            }

            return categories;
        }
    }
}
