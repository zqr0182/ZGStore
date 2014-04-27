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
        List<ProductCategoryIdName> GetActiveCategoryIdNames();
        Category GetCategoryById(int id);
        ProductCategoryEditViewModel GetCategoryEditViewModel(Category cat);
        void Update(ProductCategoryEditViewModel cat);
        void Create(ProductCategoryEditViewModel cat);
        void Activate(int id);
        void Deactivate(int id);
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
                Categories = categories.Select(c => new ProductCategoryBriefInfo{Id = c.Id, Name = c.CategoryName, ParentCategoryID = c.ParentCategoryID, Active = c.Active}).ToList(),
                Total = total
            };

            return prodCategoryListViewModel;
        }

        public List<ProductCategoryIdName> GetActiveCategoryIdNames()
        {
            var categoriesByActive = new CategoryByActive(true);
            var categories = UnitOfWork.Categories.Matches(categoriesByActive);

            return categories.Select(c => new ProductCategoryIdName { Id = c.Id, Name = c.CategoryName }).ToList();
        }

        public void Activate(int id)
        {
            ToggleActive(id, true);
        }

        public void Deactivate(int id)
        {
            ToggleActive(id, false);
        }

        public Category GetCategoryById(int id)
        {
            return UnitOfWork.Categories.MatcheById(id);
        }

        private void ToggleActive(int id, bool active)
        {
            var cat = GetCategoryById(id);
            cat.Active = active;

            UnitOfWork.Commit();
        }

        public ProductCategoryEditViewModel GetCategoryEditViewModel(Category cat)
        {
            var viewModel = new ProductCategoryEditViewModel()
            {
                Id = cat.Id,
                ParentCategoryID = cat.ParentCategoryID,
                Name = cat.CategoryName,
                Active = cat.Active,
            };

            return viewModel;
        }

        public void Update(ProductCategoryEditViewModel cat)
        {
            var category = GetCategoryById(cat.Id);
            if (category != null)
            {
                category.CategoryName = cat.Name;
                category.ParentCategoryID = cat.ParentCategoryID;
                category.Active = cat.Active;

                UnitOfWork.Commit();
            }
        }

        public void Create(ProductCategoryEditViewModel cat)
        {
            var newCat = new Category { CategoryName = cat.Name, ParentCategoryID = cat.ParentCategoryID, Active = cat.Active};

            UnitOfWork.Categories.Add(newCat);
            UnitOfWork.Commit();
        }
    }
}
