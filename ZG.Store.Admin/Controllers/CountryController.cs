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
    public class CountryController : Controller
    {
        ICountryService _countryService;
        readonly ILogger _logger;
        List<string> _countryNames = new List<string> { "Canada", "China" };

        public CountryController(ICountryService countryService, ILogger logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        public JsonResult GetCanadaChina()
        {
            var result = _countryService.GetCountyIdNames(true, _countryNames);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountryIdNames(string filterByStatus)
        {
            var active = Utility.StatusToBool(filterByStatus);
            var result = _countryService.GetCountyIdNames(active, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}