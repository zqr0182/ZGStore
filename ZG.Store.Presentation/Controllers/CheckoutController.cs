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
