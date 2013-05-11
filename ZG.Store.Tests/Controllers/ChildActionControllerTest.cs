using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZG.Store.Application;
using ZG.Store.Presentation.Controllers;

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
            string[] results = ((IEnumerable<string>)controller.Categories().Model).ToArray();

            //Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Category 1");
            Assert.AreEqual(results[1], "Category 2");
            Assert.AreEqual(results[2], "Category 3");
        }
    }
}
