using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ZG.Domain.Models;
using ZG.Application;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Presentation.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
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
        public PartialViewResult Categories(string category)
        {
            IEnumerable<string> categories = _categoryService.GetActiveCategoryNames();
            var model = new CategoriesViewModel { Categories = categories, SelectedCategory = category };

            return PartialView(model);
        }

    }
}
