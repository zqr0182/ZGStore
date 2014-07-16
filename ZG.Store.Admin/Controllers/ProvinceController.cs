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
    public class ProvinceController : Controller
    {
        IProvinceService _provinceService;
        readonly ILogger _logger;

        public ProvinceController(IProvinceService provinceService, ILogger logger)
        {
            _provinceService = provinceService;
            _logger = logger;
        }

        public JsonResult GetProvinces(int id)
        {
            var result = _provinceService.GetProvinces(null, id).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<ProvinceEditViewModel> provinces)
        {
            return UpsertProvince(provinces);
        }

        public JsonResult GetProvinceIdNames(int id)
        {
            var result = _provinceService.GetProvinceIdNames(true, id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private JsonResult UpsertProvince(List<ProvinceEditViewModel> provinces)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.JsonErrorResult();
                }

                _provinceService.Upsert(provinces);

                return this.JsonSuccessResult();
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert provinces.");
                return this.JsonErrorResult("Error occured. Unable to upsert provinces. We are fixing it.");
            }
        }
    }
}