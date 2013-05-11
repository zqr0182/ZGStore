using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZG.Store.Application;
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
            //Arrange
            var mock = new Mock<ICategoryService>();
            mock.Setup(c => c.GetActiveCategoryNames()).Returns(new [] {"Category 1", "Category 2", "Category 3"});

            //Act
            var controller = new ChildActionController(mock.Object);
            var results = (CategoriesViewModel)controller.Categories(null).Model;
            var categories = results.Categories.ToArray();

            //Assert
            Assert.AreEqual(categories.Length, 3);
            Assert.AreEqual(categories[0], "Category 1");
            Assert.AreEqual(categories[1], "Category 2");
            Assert.AreEqual(categories[2], "Category 3");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            //Arrange
            var mock = new Mock<ICategoryService>();
            mock.Setup(c => c.GetActiveCategoryNames()).Returns(new[] { "Category 1", "Category 2", "Category 3" });

            //Act
            var controller = new ChildActionController(mock.Object);
            var results = (CategoriesViewModel)controller.Categories("Category 2").Model;

            //Assert
            Assert.AreEqual(results.SelectedCategory, "Category 2");
        }
    }
}
