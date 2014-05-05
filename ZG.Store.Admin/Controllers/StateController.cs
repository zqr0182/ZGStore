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
    public class StateController : Controller
    {
        IStateService _stateService;
        readonly ILogger _logger;

        public StateController(IStateService stateService, ILogger logger)
        {
            _stateService = stateService;
            _logger = logger;
        }

        public JsonResult GetStateIdNames()
        {
            var result = _stateService.GetStateIdNames(true);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}