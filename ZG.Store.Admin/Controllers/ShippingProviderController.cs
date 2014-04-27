using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Common;
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

        public JsonResult GetShippingProviders(string filterByStatus)
        {
            var active = Utility.StatusToBool(filterByStatus);
            var result = _shippingProviderService.GetShippingProviders(active).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id)
        {
            try
            {
                var sp = _shippingProviderService.GetShippingProviderById(id);

                return Json(sp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to get supplier: {0}", id);
                return Json(new { Success = false, Error = "Error occured. Unable to get shipping provider. We are fixing it." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Edit(ShippingProvider shippingProvider)
        {
            return UpsertShippingProvider(shippingProvider);
        }

        [HttpPost]
        public JsonResult Create(ShippingProvider shippingProvider)
        {
            return UpsertShippingProvider(shippingProvider);
        }

        [HttpDelete]
        public JsonResult Deactivate(int id)
        {
            try
            {
                _shippingProviderService.Deactivate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to deactivate shipping provider {0}", id);
                return Json(new { Success = false, Error = "Error occured. Unable to deactivate shipping provider. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult Activate(int id)
        {
            try
            {
                _shippingProviderService.Activate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to activate shipping provider {0}", id);
                return Json(new { Success = false, Error = "Error occured. Unable to activate shipping provider. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        private JsonResult UpsertShippingProvider(ShippingProvider shippingProvider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                if (shippingProvider.Id > 0)
                {
                    _shippingProviderService.Update(shippingProvider);
                }
                else
                {
                    _shippingProviderService.Create(shippingProvider);
                }

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert shipping provider: {0}, {1}", shippingProvider.Id, shippingProvider.Name);
                return Json(new { Success = false, Errors = "Error occured. Unable to upsert shipping provider. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}