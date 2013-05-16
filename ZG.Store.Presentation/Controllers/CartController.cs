using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Store.Application;
using ZG.Store.Presentation.App_Code;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Presentation.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
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

            return Json(new ProductIdQuantityAndCartSummary { ProductId = id, Quantity = 0, NumberOfItems = cart.NumerbOfItems, CartTotalValue = cart.ComputeTotalValue().ToString("c") });
        }

        [HttpPost]
        public JsonResult UpdateCart(Cart cart, int id, int quantity, string returnUrl)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                cart.UpdateItem(product, quantity);
            }

            return Json(new ProductIdQuantityAndCartSummary { ProductId = id, Quantity = quantity, NumberOfItems = cart.NumerbOfItems, CartTotalValue = cart.ComputeTotalValue().ToString("c") });
        }
        
        public PartialViewResult Summary(Cart cart)
        {
            var viewModel = new SummaryViewModel { NumberOfItems = cart.NumerbOfItems, TotalValue = cart.ComputeTotalValue().ToString("c") };
            return PartialView(viewModel);
        }
    }
}
