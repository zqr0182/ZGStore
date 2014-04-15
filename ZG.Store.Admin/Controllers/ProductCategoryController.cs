using Castle.Core.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Domain.DTO;

namespace ZG.Store.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        readonly IProductCategoryService _prodCatService;
        readonly ILogger _logger;
        public ProductCategoryController(IProductCategoryService prodCatService, ILogger logger)
        {
            _prodCatService = prodCatService;
            _logger = logger;
        }

        public JsonResult List(string filterByStatus)
        {
            bool isActive = (string.Compare(filterByStatus, "active", true) == 0) ? true : false;
            var cats = _prodCatService.GetCategories(isActive, 1, 500);
            return Json(cats, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id)
        {
            try
            {
                var cat = _prodCatService.GetCategoryById(id);
                var viewModel = _prodCatService.GetCategoryEditViewModel(cat);

                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to get category: {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to get product. We are fixing it." }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Edit(ProductCategoryEditViewModel cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                _prodCatService.Update(cat);
                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to edit product category: {0}, {1}", cat.Id, cat.Name);
                return Json(new { Success = false, Errors = "Error occured, unable to edit category. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpDelete]
        public JsonResult Deactivate(int id)
        {
            try
            {
                _prodCatService.Deactivate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to deactivate category {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to deactivate category. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public JsonResult Activate(int id)
        {
            try
            {
                _prodCatService.Activate(id);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to activate category {0}", id);
                return Json(new { Success = false, Error = "Error occured, unable to activate category. We are fixing it." }, JsonRequestBehavior.DenyGet);
            }
        }

        public JsonResult GetActiveCategoryIdNames()
        {
            var cats = _prodCatService.GetActiveCategoryIdNames();
            return Json(cats, JsonRequestBehavior.AllowGet);
        }
	}
}