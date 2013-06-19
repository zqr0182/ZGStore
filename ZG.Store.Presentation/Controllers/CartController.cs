using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Common.DTO;
using ZG.Domain.Concrete;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Application;
using ZG.Store.Presentation.ViewModels;
using Address = ZG.Common.DTO.Address;

namespace ZG.Store.Presentation.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderProcessor;

        public CartController(IProductService productService, IOrderService orderProcessor)
        {
            _productService = productService;
            _orderProcessor = orderProcessor;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        public PartialViewResult GetCartContent(CartIndexViewModel cartIndexViewModel)
        {
            return PartialView(cartIndexViewModel);
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Product product = _productService.GetProductById(id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new{returnUrl});
        }

        [HttpPost]
        public JsonResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return Json(new ProductIdQuantityAndCartSummary { ProductId = id, Quantity = 0, NumberOfItems = cart.NumerbOfItems, CartTotalValue = cart.ComputeTotalItems().ToString("c") });
        }

        [HttpPost]
        public JsonResult UpdateCart(Cart cart, int id, int quantity, string returnUrl)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                cart.UpdateItem(product, quantity);
            }

            return Json(new ProductIdQuantityAndCartSummary { ProductId = id, Quantity = quantity, NumberOfItems = cart.NumerbOfItems, CartTotalValue = cart.ComputeTotalItems().ToString("c") });
        }
        
        public PartialViewResult Summary(Cart cart)
        {
            var viewModel = new SummaryViewModel { NumberOfItems = cart.NumerbOfItems, TotalValue = cart.ComputeTotalItems().ToString("c") };
            return PartialView(viewModel);
        }
    }
}
