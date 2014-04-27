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
    public class SupplierController : Controller
    {
        ISupplierService _supplierService;
        readonly ILogger _logger;
        public SupplierController(ISupplierService supplierService, ILogger logger)
        {
            _supplierService = supplierService;
            _logger = logger;
        }

        public JsonResult GetSuppliers(string filterByStatus)
        {
            var active = Utility.StatusToBool(filterByStatus);
            var result = _supplierService.GetSuppliers(active).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSupplierIdNames(string filterByStatus)
        {
            var active = Utility.StatusToBool(filterByStatus);
            var result = _supplierService.GetSupplierIdNames(active);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id)
        {
            try
            {
                var sup = _supplierService.GetSupplierById(id);

                return Json(sup, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to get supplier: {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to get supplier. We are fixing it." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Edit(Supplier sup)
        {
            return UpsertSupplier(sup);
        }

        [HttpPost]
        public JsonResult Create(Supplier sup)
        {
            return UpsertSupplier(sup);
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

        private JsonResult UpsertSupplier(Supplier sup)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                if (sup.Id > 0)
                {
                    _supplierService.Update(sup);
                }
                else
                {
                    _supplierService.Create(sup);
                }

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert supplier: {0}, {1}", sup.Id, sup.Name);
                return Json(new { Success = false, Errors = "Error occured, unable to upsert supplier. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }
	}
}