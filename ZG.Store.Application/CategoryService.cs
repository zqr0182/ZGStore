﻿using System;
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
    public interface ICategoryService
    {
        IEnumerable<string> GetActiveCategoryNames();
        CategoriesPerPage GetCategories(bool active, int page, int pageSize);
        //Category GetCategoryById(int id);
        //void Update(ProductCategoryEditViewModel prod);
        //void Activate(int prodId);
        //void Deactivate(int prodId);
    }

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork uow) : base(uow)
        {
        }

        public IEnumerable<string> GetActiveCategoryNames()
        {
            return UnitOfWork.Categories.Matches(new TopCategories(true)).Select(c => c.CategoryName).ToList();
        }


        public CategoriesPerPage GetCategories(bool active, int page, int pageSize)
        {
            var categoriesByActive = new CategoryByActive(active);
            var categories = UnitOfWork.Categories.Matches(categoriesByActive);

            var total = categories.Count();

            categories = UnitOfWork.Categories.Matches(new CategoryByPage(page, pageSize, categoriesByActive));

            var categoriesPerPage = new CategoriesPerPage()
            {
                Categories = categories.ToList(),
                TotalCategories = total
            };

            return categoriesPerPage;
        }
    }
}
