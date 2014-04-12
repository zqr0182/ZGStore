using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Repository;
using ZG.Repository.Criterias;

namespace ZG.Application
{
    public interface IProductCategoryService
    {
        IEnumerable<string> GetActiveCategoryNames();
        ProductCategoryListViewModel GetCategories(bool active, int page, int pageSize);
    }

    public class ProductCategoryService : BaseService, IProductCategoryService
    {
        public ProductCategoryService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public IEnumerable<string> GetActiveCategoryNames()
        {
            return UnitOfWork.Categories.Matches(new TopCategories(true)).Select(c => c.CategoryName).ToList();
        }


        public ProductCategoryListViewModel GetCategories(bool active, int page, int pageSize)
        {
            var categoriesByActive = new CategoryByActive(active);
            var categories = UnitOfWork.Categories.Matches(categoriesByActive);

            var total = categories.Count();

            categories = UnitOfWork.Categories.Matches(new CategoryByPage(page, pageSize, categoriesByActive));

            var prodCategoryListViewModel = new ProductCategoryListViewModel()
            {
                Categories = categories.Select(c => new ProductCategoryBriefInfo{Id = c.Id, CategoryName = c.CategoryName, ParentCategoryID = c.ParentCategoryID, Active = c.Active}),
                Total = total
            };

            return prodCategoryListViewModel;
        }
    }
}
