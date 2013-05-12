using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View(new CartIndexViewModel {Cart = cart, ReturnUrl = returnUrl});
        }

        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Product product = _productService.GetProductById(id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new{returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult UpdateCart(Cart cart, int id, int quantity, string returnUrl)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                cart.UpdateItem(product, quantity);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
