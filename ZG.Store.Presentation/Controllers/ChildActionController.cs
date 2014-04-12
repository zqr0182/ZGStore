using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using ZG.Domain.Models;
using ZG.Application;
using ZG.Store.Presentation.ViewModels;
using ZG.Domain.Concrete;
using ZG.Common;

namespace ZG.Store.Presentation.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ChildActionController : Controller
    {
        private IProductCategoryService _prodCategoryService;
        private IGeographyService _geographyService;

        public ChildActionController(IProductCategoryService categoryService, IGeographyService geographyService)
        {
            _prodCategoryService = categoryService;
            _geographyService = geographyService;
        }

        [ChildActionOnly]
        public PartialViewResult Paging(string action, string controller, string currentCagetory, int currentPageNumber, int totalPages)
        {
            var pagingViewModel = new PagingViewModel(action, controller, currentCagetory, currentPageNumber, totalPages, Url);

            return PartialView(pagingViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult CategoryLinks(string category)
        {
            IEnumerable<string> categories = _prodCategoryService.GetActiveCategoryNames();
            var model = new CategoriesViewModel { Categories = categories, SelectedCategory = category };

            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult CategoryDropdown(string category)
        {
            IEnumerable<string> categories = _prodCategoryService.GetActiveCategoryNames();
            var model = new CategoriesViewModel { Categories = categories, SelectedCategory = category };

            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult CheckoutBreadCrumbs(string activeCrumb)
        {
            if (string.Compare(activeCrumb, "shipping", true) == 0)
            {
                ViewBag.ActiveCrumb = CheckoutBreadCrumb.Shipping;
            }
            else if (string.Compare(activeCrumb, "billing", true) == 0)
            {
                ViewBag.ActiveCrumb = CheckoutBreadCrumb.Billing;
            }
            else if (string.Compare(activeCrumb, "revieworder", true) == 0)
            {
                ViewBag.ActiveCrumb = CheckoutBreadCrumb.ReviewOrder;
            }

            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult States(int? id)
        {
            var states = _geographyService.GetStates();

            var stateViewModel = new StatesViewModel { States = states, StateId = id };
            return PartialView(stateViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult Provinces(int? id)
        {
            var provinces = _geographyService.GetProvinces();

            var provinceViewModel = new ProvincesViewModel { Provinces = provinces, ProvinceId = id };
            return PartialView(provinceViewModel);
        }

        [ChildActionOnly]
        public PartialViewResult USCanada(int? id)
        {
            var usCanada = _geographyService.GetUSAndCanada();

            var viewModel = new USCanadaViewModel { USCanada = usCanada, CountryId = id };
            return PartialView(viewModel);
        }
    }
}
