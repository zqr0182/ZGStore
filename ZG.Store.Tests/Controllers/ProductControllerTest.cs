using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZG.Domain.Models;
using ZG.Store.Application;
using ZG.Store.Presentation.Controllers;

namespace ZG.Store.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange

            //var mock = new Mock<IProductService>();
            //mock.Setup(p => p.GetProducts(It.Is<int>(v => v == 2), It.Is<int>(v => v == 4))).Returns(new[]
            //    {
            //        new Product {Id = 5, ProductName = "P 5"},
            //        new Product {Id = 6, ProductName = "P 6"},
            //        new Product {Id = 7, ProductName = "P 7"}
            //    }.AsQueryable());

            //var controller = new ProductController(mock.Object);

            ////Act
            //var result = (IEnumerable<Product>)controller.List(2).Model;

            ////Assert
            //Product[] arrProd = result.ToArray();
            //Assert.IsTrue(arrProd.Length == 3);
            //Assert.AreEqual(arrProd[0].ProductName, "P 5");
            //Assert.AreEqual(arrProd[1].ProductName, "P 6");
            //Assert.AreEqual(arrProd[2].ProductName, "P 7");
        }
    }
}
