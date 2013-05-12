using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZG.Domain.Models;

namespace ZG.Store.Tests.DomainModels
{
    [TestClass]
    public class CartTest
    {
        private readonly Product _p1;
        private readonly Product _p2;
        private readonly Cart _cart;

        public CartTest()
        {
            //Arrange
            _p1 = new Product { Id = 1, ProductName = "P1", Price = 100M};
            _p2 = new Product { Id = 2, ProductName = "P2", Price = 50M};

            _cart = new Cart();
        }

        [TestMethod]
        public void Can_Add_New_Lines()
        {
            //Act
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 4);
            CartLine[] results = _cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, _p1);
            Assert.AreEqual(results[1].Product, _p2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            //Arrange
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 4);

            //Act
            _cart.AddItem(_p1, 6);
            CartLine[] results = _cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 8);
            Assert.AreEqual(results[1].Quantity, 4);
        }

        [TestMethod]
        public void Can_Update_Quantity_For_Existing_Lines()
        {
            //Arrange
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 4);

            //Act
            _cart.UpdateItem(_p1, 6);
            CartLine[] results = _cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 6);
            Assert.AreEqual(results[1].Quantity, 4);
        }

        [TestMethod]
        public void Can_Remove_Line_When_Quantity_Is_Less_Than_One()
        {
            //Arrange
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 4);

            //Act
            _cart.UpdateItem(_p1, 0);
            CartLine[] results = _cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(results.Length, 1);
            Assert.AreEqual(results[0].Quantity, 4);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            //Arrange
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 5);
            _cart.AddItem(_p1, 2);

            //Act
            _cart.RemoveLine(_p1);
            CartLine[] results = _cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(results.Length, 1);
            Assert.AreEqual(results[0].Quantity, 5);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            //Arrange
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 5);
            _cart.AddItem(_p1, 2);

            //Act
            decimal total = _cart.ComputeTotalValue();

            //Assert
            Assert.AreEqual(total, 650M);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            //Arrange
            _cart.AddItem(_p1, 2);
            _cart.AddItem(_p2, 5);
            _cart.AddItem(_p1, 2);

            //Act
            _cart.Clear();

            //Asseet
            Assert.AreEqual(_cart.Lines.Count(), 0);
        }
    }
}
