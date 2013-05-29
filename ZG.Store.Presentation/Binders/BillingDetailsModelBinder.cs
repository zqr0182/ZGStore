using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Common.DTO;
using ZG.Domain.DTO;
using ZG.Store.Presentation.App_Code;

namespace ZG.Store.Presentation.Binders
{
    public class BillingDetailsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            BillingDetails billingDetails = SessionState.BillingDetails;

            if (billingDetails == null)
            {
                billingDetails = new BillingDetails();
                SessionState.BillingDetails = billingDetails;
            }

            //TODO: update only if on billing page postback
            var form = controllerContext.HttpContext.Request.Form;
            billingDetails.FullName = form["FullName"];
            billingDetails.Address1 = form["Address"];
            billingDetails.Address2 = form["Address2"];
            billingDetails.City = form["City"];
            billingDetails.State = form["State"];
            billingDetails.Zip = form["Zip"];
            billingDetails.Country = form["Country"];
            billingDetails.Phone = form["Phone"];

            return billingDetails;
        }
    }
}