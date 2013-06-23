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
    public class CheckoutController : Controller
    {
        private IOrderService _orderProcessor;

        public CheckoutController(IOrderService orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public ViewResult Shipping(CheckoutDetails checkoutDetails)
        {
            return View(checkoutDetails.ShippingDetails);
        }

        [HttpPost]
        public ActionResult Shipping(Cart cart, CheckoutDetails checkoutDetails)
        {
            if (!cart.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                if (!checkoutDetails.IsBillingAddressAvailable())
                {
                    return RedirectToAction("Billing");
                }
                else
                {
                    return RedirectToAction("ReviewOrder");
                }
            }
            else
            {
                return View("CartEmpty");
            }
        }

        public ViewResult Billing(Cart cart, CheckoutDetails checkoutDetails)
        {
            var billingViewModel = new BillingViewModel()
            {
                NewBillingAddress = new Address(),
                ExistingBillingAddress = checkoutDetails.PaymentInformation.BillingAdress,
                ShippingAddress = checkoutDetails.ShippingDetails.ShippingAddress
            };
            return View("Billing", billingViewModel);
        }

        public ViewResult ReviewOrder(Cart cart, CheckoutDetails checkoutDetails)
        {
            if (!cart.Lines.Any() || string.IsNullOrWhiteSpace(checkoutDetails.ShippingDetails.ShippingAddress.FullName) || string.IsNullOrWhiteSpace(checkoutDetails.PaymentInformation.BillingAdress.FullName))
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            { 
                var reviewOrderViewModel = new ReviewOrderViewModel {Cart = cart, CheckoutDetails = checkoutDetails};
                return View(reviewOrderViewModel);
            }
            else
            {
                return View("CartEmpty");
            }
        }

        [HttpPost]
        public ViewResult PlaceOrder(Cart cart, CheckoutDetails checkoutDetails)
        {
            if (ModelState.IsValid)
            {
                _orderProcessor.ProcessOrder(cart, checkoutDetails);
                cart.Clear();

                return View("OrderConfirmation");
            }
            else
            {
                var reviewOrderViewModel = new ReviewOrderViewModel { Cart = cart, CheckoutDetails = checkoutDetails };
                return View("ReviewOrder", reviewOrderViewModel);
            }
        }
    }
}
