using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Store.Presentation.ViewModels;

namespace ZG.Store.Presentation.Controllers
{
    public class ChildActionController : Controller
    {
        //
        // GET: /ChildAction/

        [ChildActionOnly]
        public PartialViewResult Paging(string action, string controller, int currentPageNumber, int totalPages)
        {
            var pagingViewModel = new PagingViewModel(action, controller, currentPageNumber, totalPages, Url);

            return PartialView(pagingViewModel);
        }

    }
}
