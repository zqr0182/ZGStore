using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;

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
	}
}