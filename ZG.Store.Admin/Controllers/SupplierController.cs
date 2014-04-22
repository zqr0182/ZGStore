using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Common;

namespace ZG.Store.Admin.Controllers
{
    public class SupplierController : Controller
    {
        ISupplierService _supplierService;
        readonly ILogger _logger;
        public SupplierController(ISupplierService supplierService, ILogger logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        public JsonResult GetSupplierIdNames(string filterByStatus)
        {
            var active = string.Compare(filterByStatus, "Active", true) == 0 ? true : false;
            var result = _supplierService.GetSupplierIdNames(active);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Deactivate(int id)
        {
            try
            {
                _supplierService.Deactivate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to deactivate product {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to deactivate product. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult Activate(int id)
        {
            try
            {
                _supplierService.Activate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to activate product {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to activate product. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }
	}
}