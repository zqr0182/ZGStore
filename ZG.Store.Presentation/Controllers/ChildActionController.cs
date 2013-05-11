using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Domain.Models;
using ZG.Store.Application;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Presentation.Controllers
{
    public class ChildActionController : Controller
    {
        private ICategoryService _categoryService;

        public ChildActionController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ChildActionOnly]
        public PartialViewResult Paging(string action, string controller, string currentCagetory, int currentPageNumber, int totalPages)
        {
            var pagingViewModel = new PagingViewModel(action, controller, currentCagetory, currentPageNumber, totalPages, Url);

            return PartialView(pagingViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            IEnumerable<string> categories = _categoryService.GetActiveCategoryNames();

            return PartialView(categories);
        }

    }
}
