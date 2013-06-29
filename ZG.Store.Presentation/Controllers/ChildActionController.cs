﻿using System;
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
        private ICategoryService _categoryService;
        private IGeographyService _geographyService;

        public ChildActionController(ICategoryService categoryService, IGeographyService geographyService)
        {
            _categoryService = categoryService;
            _geographyService = geographyService;
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
        public PartialViewResult Countries(int? id)
        {
            var countries = _geographyService.GetCountries();

            var countryViewModel = new CountriesViewModel { Countries = countries, CountryId = id };
            return PartialView(countryViewModel);
        }
    }
}
