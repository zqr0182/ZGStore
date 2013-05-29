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
    public class ShippingDetailsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ShippingDetails shippingDetails = SessionState.ShippingDetails;

            if (shippingDetails == null)
            {
                shippingDetails = new ShippingDetails();
                SessionState.ShippingDetails = shippingDetails;
            }

            //TODO: update only if on shipping page postback
            var form = controllerContext.HttpContext.Request.Form;
            shippingDetails.FullName = form["FullName"];
            shippingDetails.Address1 = form["Address"];
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

            return shippingDetails;
        }
    }
}