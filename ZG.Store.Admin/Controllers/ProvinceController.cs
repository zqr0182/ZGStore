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
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                _provinceService.Upsert(provinces);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert provinces.");
                return Json(new { Success = false, Errors = new []{"Error occured. Unable to upsert provinces. We are fixing it." }}, JsonRequestBehavior.DenyGet);
            }
        }
    }
}