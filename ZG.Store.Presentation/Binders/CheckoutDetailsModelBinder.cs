﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZG.Domain.Concrete;
using ZG.Store.Presentation.App_Code;

namespace ZG.Store.Presentation.Binders
{
    public class CheckoutDetailsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CheckoutDetails checkoutDetails = SessionState.CheckoutDetails;

            if (checkoutDetails == null)
            {
                checkoutDetails = new CheckoutDetails();
                SessionState.CheckoutDetails = checkoutDetails;
            }

            RouteData routeData = controllerContext.RouteData; 
            if (string.Compare(routeData.Values["controller"].ToString(), "Cart", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(routeData.Values["action"].ToString(), "ReviewOrder", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(controllerContext.HttpContext.Request.HttpMethod, "POST", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                var billingDetails = checkoutDetails.PaymentInformation;

                bool sameAddress;
                if (bool.TryParse(controllerContext.HttpContext.Request.QueryString["SameAddress"], out sameAddress) && sameAddress)
                {
                    var shippingDetails = checkoutDetails.ShippingDetails;

                    billingDetails.BillingAdress.FullName = shippingDetails.ShippingAddress.FullName;
                    billingDetails.BillingAdress.Address1 = shippingDetails.ShippingAddress.Address1;
                    billingDetails.BillingAdress.Address2 = shippingDetails.ShippingAddress.Address2;
                    billingDetails.BillingAdress.City = shippingDetails.ShippingAddress.City;
                    billingDetails.BillingAdress.State = shippingDetails.ShippingAddress.State;
                    billingDetails.BillingAdress.Zip = shippingDetails.ShippingAddress.Zip;
                    billingDetails.BillingAdress.Country = shippingDetails.ShippingAddress.Country;
                    billingDetails.BillingAdress.Phone = shippingDetails.ShippingAddress.Phone;
                }
                else
                {
                    var form = controllerContext.HttpContext.Request.Form;

                    billingDetails.BillingAdress.FullName = form["BillingAddress.FullName"];
                    billingDetails.BillingAdress.Address1 = form["BillingAddress.Address"];
                    billingDetails.BillingAdress.Address2 = form["BillingAddress.Address2"];
                    billingDetails.BillingAdress.City = form["BillingAddress.City"];
                    billingDetails.BillingAdress.State = form["BillingAddress.State"];
                    billingDetails.BillingAdress.Zip = form["BillingAddress.Zip"];
                    billingDetails.BillingAdress.Country = form["BillingAddress.Country"];
                    billingDetails.BillingAdress.Phone = form["BillingAddress.Phone"];
                }
            }

            if (string.Compare(routeData.Values["controller"].ToString(), "Cart", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(routeData.Values["action"].ToString(), "Shipping", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(controllerContext.HttpContext.Request.HttpMethod, "POST", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                var form = controllerContext.HttpContext.Request.Form;

                var shippingDetails = checkoutDetails.ShippingDetails;
                shippingDetails.ShippingAddress.FullName = form["ShippingAddress.FullName"];
                shippingDetails.ShippingAddress.Address1 = form["ShippingAddress.Address1"];
                shippingDetails.ShippingAddress.Address2 = form["ShippingAddress.Address2"];
                shippingDetails.ShippingAddress.City = form["ShippingAddress.City"];
                shippingDetails.ShippingAddress.State = form["ShippingAddress.State"];
                shippingDetails.ShippingAddress.Zip = form["ShippingAddress.Zip"];
                shippingDetails.ShippingAddress.Country = form["ShippingAddress.Country"];
                shippingDetails.ShippingAddress.Phone = form["ShippingAddress.Phone"];
                bool giftWrap;
                if (bool.TryParse(form["GiftWrap"], out giftWrap))
                {
                    shippingDetails.GiftWrap = giftWrap;
                }
            }

            return checkoutDetails;
        }
    }
}