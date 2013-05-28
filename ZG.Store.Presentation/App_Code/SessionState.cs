using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Domain.Concrete;

namespace ZG.Store.Presentation.App_Code
{
    public class SessionState
    {
        public static Cart Cart
        {
            get { return (Cart)HttpContext.Current.Session["Cart"]; }
            set { HttpContext.Current.Session["Cart"] = value; }
        }
    }
}