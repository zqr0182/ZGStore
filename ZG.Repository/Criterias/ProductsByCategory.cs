using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository.Criterias
{
    public class ProductsByCategory : AbstractCriteria<Product>
    {
        private readonly string _category;
        private readonly bool _isActive;

        public ProductsByCategory(string category, bool isActive)
        {
            _category = category;
            _isActive = isActive;
        }

        public override IQueryable<Product> BuildQueryOver(IQueryable<Product> queryBase)
        {
            IQueryable<Product> products = base.BuildQueryOver(queryBase);
            return products.Include("ProductCategories.Category")
                           .Where(p => p.Active == _isActive && p.ProductCategories.Any(pc => _category == null || pc.Category.CategoryName == _category))
                           .Select(p => p);
        }
    }
}
