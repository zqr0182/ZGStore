using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZG.Application;
using ZG.Store.Presentation.Controllers;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Tests.Controllers
{
    [TestClass]
    public class ChildActionControllerTest
    {
        [TestMethod]
        public void Can_Get_Categories()
        {
            ////Arrange
            //var mockCategoryService = new Mock<ICategoryService>();
            //mockCategoryService.Setup(c => c.GetActiveCategoryNames()).Returns(new[] { "Category 1", "Category 2", "Category 3" });

            //var mockGeographyService = new Mock<IGeographyService>();

            ////Act
            //var controller = new ChildActionController(mockCategoryService.Object, mockGeographyService.Object);
            //var results = (CategoriesViewModel)controller.Categories(null).Model;
            //var categories = results.Categories.ToArray();

            ////Assert
            //Assert.AreEqual(categories.Length, 3);
            //Assert.AreEqual(categories[0], "Category 1");
            //Assert.AreEqual(categories[1], "Category 2");
            //Assert.AreEqual(categories[2], "Category 3");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            ////Arrange
            //var mockCategoryService = new Mock<ICategoryService>();
            //mockCategoryService.Setup(c => c.GetActiveCategoryNames()).Returns(new[] { "Category 1", "Category 2", "Category 3" });

            //var mockGeographyService = new Mock<IGeographyService>();

            ////Act
            //var controller = new ChildActionController(mockCategoryService.Object, mockGeographyService.Object);
            //var results = (CategoriesViewModel)controller.Categories("Category 2").Model;

            ////Assert
            //Assert.AreEqual(results.SelectedCategory, "Category 2");
        }
    }
}
