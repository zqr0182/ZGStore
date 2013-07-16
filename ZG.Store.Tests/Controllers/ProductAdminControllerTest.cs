using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Application;
using ZG.Store.Presentation.Controllers;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Tests.Controllers
{
    [TestClass]
    public class ProductAdminControllerTest
    {
        [TestMethod]
        public void ProductListViewModel_Is_Correct()
        {
            //Arrange
            const int ProdsPerPage = 20;
            const int TotalProducts = 50;
            string category = "Category 2";
            const int CategoryId = 17;
            int page = 1;
            Mock<IProductService> mock = new Mock<IProductService>();
            mock.Setup(m => m.GetActiveProducts(category, page, ProdsPerPage)).Returns(new ProductsPerPage()
            {
                Products = new Product[]{ new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                                           new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},
                 new Product{ ProductCategories = new ProductCategory[]{ new ProductCategory{ CategoryID = CategoryId }}},}.AsQueryable(),
                 TotalProducts = TotalProducts
            });

            var prodAdminController = new ProductAdminController(mock.Object);

            //Act
            var viewModel = ((ProductListViewModel)(prodAdminController.List(category, page).ViewData.Model));

            //Assert
            Assert.IsTrue(viewModel.Products.Count() == ProdsPerPage);
            Assert.IsTrue(viewModel.CurrentPageNum == page);
            Assert.IsTrue(viewModel.CurrentCategory == category);
            Assert.IsTrue(viewModel.RecordsPerPage == ProdsPerPage);
            Assert.IsTrue(viewModel.TotalPages == Math.Ceiling((double)TotalProducts / ProdsPerPage));
        }
    }
}
