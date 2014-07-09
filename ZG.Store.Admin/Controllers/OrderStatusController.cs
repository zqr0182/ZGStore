using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;

namespace ZG.Store.Admin.Controllers
{
    public class OrderStatusController : Controller
    {
        readonly IOrderStatusService _orderStatusService;
        readonly ILogger _logger;

        public OrderStatusController(IOrderStatusService orderStatusService, ILogger logger)
        {
            _orderStatusService = orderStatusService;
            _logger = logger;
        }

        public JsonResult Index()
        {
            var result = _orderStatusService.GetStatusIdName(true);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
	}
}