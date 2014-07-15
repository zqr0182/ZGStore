using Castle.Core.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Domain.DTO;
using ZG.Store.Admin.App_Code;

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
                return Json(new { Success = false, Error = new []{"Error occured, unable to get product. We are fixing it."} }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Edit(ProductCategoryEditViewModel cat)
        {
            return UpsertProductCategory(cat);
        }

        [HttpPost]
        public JsonResult Create(ProductCategoryEditViewModel cat)
        {
            return UpsertProductCategory(cat);
        }

        [HttpDelete]
        public JsonResult Deactivate(int id)
        {
            try
            {
                _prodCatService.Deactivate(id);

                return this.JsonSuccessResult();
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to deactivate category {0}", id);
                return Json(new { Success = false, Error = new []{"Error occured, unable to deactivate category. We are fixing it." }}, JsonRequestBehavior.DenyGet);
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
                return Json(new { Success = false, Error = new []{"Error occured, unable to activate category. We are fixing it." }}, JsonRequestBehavior.DenyGet);
            }
        }

        public JsonResult GetActiveCategoryIdNames()
        {
            var cats = _prodCatService.GetActiveCategoryIdNames();
            return Json(cats, JsonRequestBehavior.AllowGet);
        }

        private JsonResult UpsertProductCategory(ProductCategoryEditViewModel cat)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.JsonErrorResult();
                }

                if (cat.Id > 0)
                {
                    _prodCatService.Update(cat);
                }
                else
                {
                    _prodCatService.Create(cat);
                }

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert product category: {0}, {1}", cat.Id, cat.Name);
                return Json(new { Success = false, Errors = new []{"Error occured, unable to upsert category. We are fixing it." }}, JsonRequestBehavior.DenyGet);
            }
        }
	}
}