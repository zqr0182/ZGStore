using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Common;
using ZG.Domain.DTO;
using ZG.Domain.Models;
using ZG.Store.Admin.App_Code;

namespace ZG.Store.Admin.Controllers
{
    public class ShippingProviderController : Controller
    {
        IShippingProviderService _shippingProviderService;
        readonly ILogger _logger;

        public ShippingProviderController(IShippingProviderService shippingProviderService, ILogger logger)
        {
            _shippingProviderService = shippingProviderService;
            _logger = logger;
        }

        public JsonResult GetShippingProviders()
        {
            var result = _shippingProviderService.GetShippingProviders(null).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<ShippingProviderEditViewModel> shippingProviders)
        {
            return UpsertShippingProvider(shippingProviders);
        }

        public JsonResult GetShippingProviderIdNames()
        {
            var result = _shippingProviderService.GetShippingProviderIdNames(true);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private JsonResult UpsertShippingProvider(List<ShippingProviderEditViewModel> shippingProviders)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.JsonErrorResult();
                }

                _shippingProviderService.Upsert(shippingProviders);

                return this.JsonSuccessResult();
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert shipping providers.");
                return this.JsonErrorResult("Error occured. Unable to upsert shipping provider. We are fixing it.");
            }
        }
    }
}