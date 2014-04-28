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

        private JsonResult UpsertShippingProvider(List<ShippingProviderEditViewModel> shippingProviders)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                _shippingProviderService.Upsert(shippingProviders);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert shipping providers.");
                return Json(new { Success = false, Errors = "Error occured. Unable to upsert shipping provider. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}