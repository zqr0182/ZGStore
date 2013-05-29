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

        public static ShippingDetails ShippingDetails
        {
            get { return (ShippingDetails)HttpContext.Current.Session["ShippingDetails"]; }
            set { HttpContext.Current.Session["ShippingDetails"] = value; }
        }

        public static BillingDetails BillingDetails
        {
            get { return (BillingDetails)HttpContext.Current.Session["BillingDetails"]; }
            set { HttpContext.Current.Session["BillingDetails"] = value; }
        }
    }
}