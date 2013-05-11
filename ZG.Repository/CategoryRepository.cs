using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.Models;

namespace ZG.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<string> GetActiveCategoryNames();
    }

    public class CategoryRepository : ZGStoreRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ZGStoreContext context) : base(context) { }

        public IEnumerable<string> GetActiveCategoryNames()
        {
            return GetCategories(true).Select(c => c.CategoryName).ToList();
        }

        private IQueryable<Category> GetCategories(bool activeOnly)
        {
            return FindWhere(c => c.Active == activeOnly && !c.ParentCategoryID.HasValue).OrderBy(c => c.CategoryName);
        }
    }
}
