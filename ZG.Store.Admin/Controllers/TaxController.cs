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
    public class TaxController : Controller
    {
        ITaxService _taxService;
        readonly ILogger _logger;

        public TaxController(ITaxService taxService, ILogger logger)
        {
            _taxService = taxService;
            _logger = logger;
        }

        public JsonResult GetTaxes(int id)
        {
            var result = _taxService.GetTaxes(null, id).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<TaxViewModel> taxes)
        {
            return UpsertTax(taxes);
        }

        private JsonResult UpsertTax(List<TaxViewModel> taxes)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                _taxService.Upsert(taxes);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert taxes.");
                return Json(new { Success = false, Errors = new[] { "Error occured. Unable to upsert taxes. We are fixing it." } }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}