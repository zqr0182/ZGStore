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

        public ViewResult Shipping(CheckoutDetails checkoutDetails)
        {
            return View(checkoutDetails.ShippingDetails);
        }

        [HttpPost]
        public ViewResult Shipping(Cart cart, CheckoutDetails checkoutDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                if (!checkoutDetails.IsBillingAddressAvailable())
                {
                    //var billingViewModel = new BillingViewModel()
                    //    {
                    //        BillingAddress = new Address(),
                    //        ShippingAddress = checkoutDetails.ShippingDetails.ShippingAddress
                    //    };
                    //return View("Billing", billingViewModel);

                    return Billing(checkoutDetails);
                }
                else
                {
                    var reviewOrderViewModel = new ReviewOrderViewModel { Cart = cart, CheckoutDetails = checkoutDetails };
                    return View("ReviewOrder", reviewOrderViewModel);
                }
            }
            else
            {
                return View(checkoutDetails.ShippingDetails);
            }
        }

        public ViewResult Billing(CheckoutDetails checkoutDetails)
        {
            var billingViewModel = new BillingViewModel()
            {
                NewBillingAddress = new Address(),
                ExistingBillingAddress = checkoutDetails.PaymentInformation.BillingAdress,
                ShippingAddress = checkoutDetails.ShippingDetails.ShippingAddress
            };
            return View("Billing", billingViewModel);
        }

        [HttpPost]
        public ViewResult ReviewOrder(Cart cart, CheckoutDetails checkoutDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (string.IsNullOrWhiteSpace(checkoutDetails.ShippingDetails.ShippingAddress.FullName))
            {
                ModelState.AddModelError("", "Sorry, your shipping details is empty!");
            }

            if (ModelState.IsValid)
            {
                //TODO: move these code into checkout action
                //_orderProcessor.ProcessOrder(cart, shipping, billing);
                //cart.Clear();

                var reviewOrderViewModel = new ReviewOrderViewModel {Cart = cart, CheckoutDetails = checkoutDetails};
                return View(reviewOrderViewModel);
            }
            else
            {
                return Billing(checkoutDetails);
            }
        }
    }
}
