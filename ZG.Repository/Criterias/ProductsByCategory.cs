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
        private readonly bool _activeOnly;

        public ProductsByCategory(string category, bool activeOnly)
        {
            _category = category;
            _activeOnly = activeOnly;
        }

        public override IQueryable<Product> BuildQueryOver(IQueryable<Product> queryBase)
        {
            IQueryable<Product> products = base.BuildQueryOver(queryBase);
            if (Context != null)
            {
                //the generated query executes faster than the other one.
                return (from prod in products
                        join prodCat in Context.ProductCategories on prod.Id equals prodCat.ProductID
                        join cat in Context.Categories on prodCat.CategoryID equals cat.Id
                        where prod.Active == _activeOnly && (_category == null || cat.CategoryName == _category)
                        select prod);
            }
            
            return products.Where(p => p.Active == _activeOnly)
                           .SelectMany(p => p.ProductCategories
                                             .Where(c => _category == null || c.Category.CategoryName == _category)
                                             .Select(c => c.Product));
        }
    }
}
