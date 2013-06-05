using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZG.Common.DTO;
using ZG.Domain.DTO;
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
                var billingDetails = checkoutDetails.BillingDetails;

                bool sameAddress;
                if (bool.TryParse(controllerContext.HttpContext.Request.QueryString["SameAddress"], out sameAddress) && sameAddress)
                {
                    var shippingDetails = checkoutDetails.ShippingDetails;

                    billingDetails.FullName = shippingDetails.FullName;
                    billingDetails.Address1 = shippingDetails.Address1;
                    billingDetails.Address2 = shippingDetails.Address2;
                    billingDetails.City = shippingDetails.City;
                    billingDetails.State = shippingDetails.State;
                    billingDetails.Zip = shippingDetails.Zip;
                    billingDetails.Country = shippingDetails.Country;
                    billingDetails.Phone = shippingDetails.Phone;
                }
                else
                {
                    var form = controllerContext.HttpContext.Request.Form;

                    billingDetails.FullName = form["BillingDetails.FullName"];
                    billingDetails.Address1 = form["BillingDetails.Address"];
                    billingDetails.Address2 = form["BillingDetails.Address2"];
                    billingDetails.City = form["BillingDetails.City"];
                    billingDetails.State = form["BillingDetails.State"];
                    billingDetails.Zip = form["BillingDetails.Zip"];
                    billingDetails.Country = form["BillingDetails.Country"];
                    billingDetails.Phone = form["BillingDetails.Phone"];
                }
            }

            if (string.Compare(routeData.Values["controller"].ToString(), "Cart", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(routeData.Values["action"].ToString(), "Shipping", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(controllerContext.HttpContext.Request.HttpMethod, "POST", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                var form = controllerContext.HttpContext.Request.Form;

                var shippingDetails = checkoutDetails.ShippingDetails;
                shippingDetails.FullName = form["FullName"];
                shippingDetails.Address1 = form["Address1"];
                shippingDetails.Address2 = form["Address2"];
                shippingDetails.City = form["City"];
                shippingDetails.State = form["State"];
                shippingDetails.Zip = form["Zip"];
                shippingDetails.Country = form["Country"];
                shippingDetails.Phone = form["Phone"];
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