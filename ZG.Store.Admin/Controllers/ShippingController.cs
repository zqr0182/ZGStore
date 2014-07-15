﻿using Castle.Core.Logging;
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
    public class ShippingController : Controller
    {
        IShippingService _shippingService;
        readonly ILogger _logger;

        public ShippingController(IShippingService shippingService, ILogger logger)
        {
            _shippingService = shippingService;
            _logger = logger;
        }

        public JsonResult GetShippings(int id)
        {
            var result = _shippingService.GetShippings(null, id).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<ShippingEditViewModel> shippings)
        {
            return UpsertShipping(shippings);
        }

        private JsonResult UpsertShipping(List<ShippingEditViewModel> shippings)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.JsonErrorResult();
                }

                _shippingService.Upsert(shippings);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert shippings.");
                return this.JsonErrorResult("Error occured. Unable to upsert shippings. We are fixing it.");
            }
        }
    }
}