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
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public JsonResult GetActiveSupplierIdNames()
        {
            var result = _supplierService.GetSupplierIdNames(SupplierStatus.Active);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}