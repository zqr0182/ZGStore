using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ZG.Domain.Concrete;
using ZG.Domain.Models;
using ZG.Store.Application;
using ZG.Store.Presentation.Controllers;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        private CartController _cartController;
        private Mock<IProductService> _mock;

        public CartControllerTest()
        {
            _mock = new Mock<IProductService>();
            _cartController = new CartController(_mock.Object);
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            //Arrange
            var cart = new Cart();

            //Act
            var results = (CartIndexViewModel)_cartController.Index(cart, "myUrl").Model;

            //Assert
            Assert.AreSame(results.Cart, cart);
            Assert.AreEqual(results.ReturnUrl, "myUrl");
        }

        [TestMethod]
        public void Can_Add_To_Cart()
        {
            //Arrange
            const int productId = 2;
            var cart = new Cart();

            _mock.Setup(p => p.GetProductById(It.Is<int>(v => v == productId))).Returns(new Product { Id = productId, ProductName = "P2" });

            //Act
            _cartController.AddToCart(cart, productId, null);

            //Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.Id, productId);
        }

        [TestMethod]
        public void Adding_To_Cart_Goes_To_Cart_Screen()
        {
            //Arrange
            const int productId = 2;
            var cart = new Cart();

            _mock.Setup(p => p.GetProductById(It.Is<int>(v => v == productId))).Returns(new Product { Id = productId, ProductName = "P2" });

            //Act
            RedirectToRouteResult results = _cartController.AddToCart(cart, productId, "myUrl");

            //Assert
            Assert.AreEqual(results.RouteValues["action"], "Index");
            Assert.AreEqual(results.RouteValues["returnUrl"], "myUrl");
        }
    }
}
