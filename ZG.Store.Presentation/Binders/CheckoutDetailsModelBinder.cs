using System;
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
            if (string.Compare(routeData.Values["controller"].ToString(), "Checkout", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(routeData.Values["action"].ToString(), "ReviewOrder", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(controllerContext.HttpContext.Request.HttpMethod, "POST", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                var billingDetails = checkoutDetails.PaymentInformation;

                string existingAddressToUse = controllerContext.HttpContext.Request.QueryString["useExisting"];
                if (existingAddressToUse == "shipping")
                {
                    var shippingDetails = checkoutDetails.ShippingDetails;

                    billingDetails.BillingAdress.FullName = shippingDetails.ShippingAddress.FullName;
                    billingDetails.BillingAdress.Address1 = shippingDetails.ShippingAddress.Address1;
                    billingDetails.BillingAdress.Address2 = shippingDetails.ShippingAddress.Address2;
                    billingDetails.BillingAdress.CountryId = shippingDetails.ShippingAddress.CountryId;
                    billingDetails.BillingAdress.StateId = shippingDetails.ShippingAddress.StateId;
                    billingDetails.BillingAdress.State = shippingDetails.ShippingAddress.State;
                    billingDetails.BillingAdress.ProvinceId = shippingDetails.ShippingAddress.ProvinceId;
                    billingDetails.BillingAdress.Province = shippingDetails.ShippingAddress.Province;
                    billingDetails.BillingAdress.City = shippingDetails.ShippingAddress.City;
                    billingDetails.BillingAdress.Zip = shippingDetails.ShippingAddress.Zip;
                    billingDetails.BillingAdress.Phone = shippingDetails.ShippingAddress.Phone;
                }
                else if (existingAddressToUse == "billing")
                {
                    //do nothing
                }
                else
                {
                    var form = controllerContext.HttpContext.Request.Form;

                    billingDetails.BillingAdress.FullName = form["NewBillingAddress.FullName"];
                    billingDetails.BillingAdress.Address1 = form["NewBillingAddress.Address1"];
                    billingDetails.BillingAdress.Address2 = form["NewBillingAddress.Address2"];
                    billingDetails.BillingAdress.CountryId = int.Parse(form["CountryId"]);

                    int stateId;
                    int.TryParse(form["StateId"], out stateId);
                    billingDetails.BillingAdress.StateId = stateId;
                    billingDetails.BillingAdress.State = form["State"];

                    int provinceId;
                    int.TryParse(form["ProvinceId"], out provinceId);
                    billingDetails.BillingAdress.ProvinceId = provinceId;
                    billingDetails.BillingAdress.Province = form["Province"];

                    billingDetails.BillingAdress.City = form["NewBillingAddress.City"];
                    billingDetails.BillingAdress.Zip = form["NewBillingAddress.Zip"];
                    billingDetails.BillingAdress.Phone = form["NewBillingAddress.Phone"];
                }
            }

            if (string.Compare(routeData.Values["controller"].ToString(), "Checkout", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(routeData.Values["action"].ToString(), "Shipping", StringComparison.InvariantCultureIgnoreCase) == 0 &&
                string.Compare(controllerContext.HttpContext.Request.HttpMethod, "POST", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                var form = controllerContext.HttpContext.Request.Form;

                var shippingDetails = checkoutDetails.ShippingDetails;
                shippingDetails.ShippingAddress.FullName = form["ShippingAddress.FullName"];
                shippingDetails.ShippingAddress.Address1 = form["ShippingAddress.Address1"];
                shippingDetails.ShippingAddress.Address2 = form["ShippingAddress.Address2"];
                shippingDetails.ShippingAddress.CountryId = int.Parse(form["CountryId"]);

                int stateId;
                int.TryParse(form["StateId"], out stateId);
                shippingDetails.ShippingAddress.StateId = stateId;
                shippingDetails.ShippingAddress.State = form["State"];

                int provinceId;
                int.TryParse(form["ProvinceId"], out provinceId);
                shippingDetails.ShippingAddress.ProvinceId = provinceId;
                shippingDetails.ShippingAddress.Province = form["Province"];

                shippingDetails.ShippingAddress.City = form["ShippingAddress.City"];
                shippingDetails.ShippingAddress.Zip = form["ShippingAddress.Zip"];
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