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
    public class StoreConfigurationsController : Controller
    {
        IStoreConfigurationsService _configService;
        readonly ILogger _logger;

        public StoreConfigurationsController(IStoreConfigurationsService configService, ILogger logger)
        {
            _configService = configService;
            _logger = logger;
        }

        public JsonResult List(string filterByStatus)
        {
            var result = GetStoreConfigurations(filterByStatus);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<StoreConfiguration> storeConfigs, string filterByStatus)
        {
            return UpsertStoreConfigurations(storeConfigs, filterByStatus);
        }

        private JsonResult UpsertStoreConfigurations(List<StoreConfiguration> storeConfigs, string filterByStatus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.JsonErrorResult();
                }

                _configService.Upsert(storeConfigs);
                var configsInDb = GetStoreConfigurations(filterByStatus);

                return Json(new { Success = true, StoreConfigurations = configsInDb }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert storeConfigurations.");
                return this.JsonErrorResult("Error occured. Unable to upsert storeConfigurations. We are fixing it.");
            }
        }

        private List<StoreConfiguration> GetStoreConfigurations(string filterByStatus)
        {
            bool isActive = (string.Compare(filterByStatus, "active", true) == 0) ? true : false;

            return _configService.GetStoreConfigurations(isActive).ToList();
        }
    }
}