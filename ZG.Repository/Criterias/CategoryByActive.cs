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
        private bool _isActive;

        public CategoryByActive(bool isActive)
        {
            _isActive = isActive;
        }

        public override IQueryable<Category> BuildQueryOver(IQueryable<Category> queryBase)
        {
            IQueryable<Category> categories = base.BuildQueryOver(queryBase);

            return categories.Where(s => s.Active == _isActive);
        }
    }
}
