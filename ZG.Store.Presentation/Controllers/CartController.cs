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

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel {Cart = GetCart(), ReturnUrl = returnUrl});
        }

        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            Product product = _productService.GetProductById(id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new{returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            var cart = SessionState.Cart;
            if (cart == null)
            {
                cart = new Cart();
                SessionState.Cart = cart;
            }

            return cart;
        }

    }
}
