﻿using System;
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
    public class ProductControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            var products = new[]
                    {
                        new Product {Id = 5, Name = "P 5"}, new Product {Id = 6, Name = "P 6"}, new Product {Id = 7, Name = "P 7"}
                    }.AsQueryable();

            var mock = new Mock<IProductService>();
            mock.Setup(p => p.GetActiveProducts(null, It.Is<int>(v => v == 2), It.Is<int>(v => v == 4)))
                .Returns(new ProductsPerPage { Products = products, TotalProducts = 7 });

            var controller = new ProductController(mock.Object);

            //Act
            var result = (ProductListViewModel)controller.List(null, 2).Model;

            //Assert
            Product[] arrProd = result.Products.ToArray();
            Assert.IsTrue(arrProd.Length == 3);
            Assert.AreEqual(arrProd[0].Name, "P 5");
            Assert.AreEqual(arrProd[1].Name, "P 6");
            Assert.AreEqual(arrProd[2].Name, "P 7");
            Assert.AreEqual(result.CurrentPageNum, 2);
            Assert.AreEqual(result.RecordsPerPage, 4);
            Assert.AreEqual(result.TotalPages, 2);
            Assert.IsNull(result.CurrentCategory);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            //Arrange
            string category = "Category 2";
            var products = new[]{new Product {Id = 5, Name = "P 5"}, new Product {Id = 6, Name = "P 6"}, new Product {Id = 7, Name = "P 7"}, new Product {Id = 8, Name = "P 8"}
                    }.AsQueryable();

            var mock = new Mock<IProductService>();
            mock.Setup(p => p.GetActiveProducts(category, It.Is<int>(v => v == 1), It.Is<int>(v => v == 4)))
                .Returns(new ProductsPerPage {Products = products, TotalProducts = 5});

            var controller = new ProductController(mock.Object);

            //Act
            var result = (ProductListViewModel)controller.List(category, 1).Model;

            //Assert
            Product[] arrProd = result.Products.ToArray();
            Assert.IsTrue(arrProd.Length == 4);
            Assert.AreEqual(arrProd[0].Name, "P 5");
            Assert.AreEqual(arrProd[1].Name, "P 6");
            Assert.AreEqual(arrProd[2].Name, "P 7");
            Assert.AreEqual(arrProd[3].Name, "P 8");
            Assert.AreEqual(result.CurrentPageNum, 1);
            Assert.AreEqual(result.RecordsPerPage, 4);
            Assert.AreEqual(result.TotalPages, 2);
            Assert.AreEqual(result.CurrentCategory, category);
        }
    }
}
