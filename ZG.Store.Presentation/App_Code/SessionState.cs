using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Common.DTO;
using ZG.Domain.Concrete;
using ZG.Domain.DTO;

namespace ZG.Store.Presentation.App_Code
{
    public class SessionState
    {
        public static Cart Cart
        {
            get { return (Cart)HttpContext.Current.Session["Cart"]; }
            set { HttpContext.Current.Session["Cart"] = value; }
        }

        public static CheckoutDetails CheckoutDetails
        {
            get { return (CheckoutDetails)HttpContext.Current.Session["CheckoutDetails"]; }
            set { HttpContext.Current.Session["CheckoutDetails"] = value; }
        }

        public static ShippingDetails ShippingDetails
        {
            get { return (ShippingDetails)HttpContext.Current.Session["ShippingDetails"]; }
            set { HttpContext.Current.Session["ShippingDetails"] = value; }
        }

        public static PaymentInformation PaymentInformation
        {
            get { return (PaymentInformation)HttpContext.Current.Session["PaymentInformation"]; }
            set { HttpContext.Current.Session["PaymentInformation"] = value; }
        }
    }
}