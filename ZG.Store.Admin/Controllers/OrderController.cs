using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Domain.Models;
using Newtonsoft.Json;
using ZG.Common;
using ZG.Store.Admin.App_Code;
using ZG.Domain.DTO;
using Castle.Core.Logging;

namespace ZG.Store.Admin.Controllers
{
    public class OrderController : Controller
    {
        readonly IOrderService _orderService;
        readonly ILogger _logger;
        public OrderController(IOrderService orderService, ILogger logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public JsonResult List(string filterByStatus)
        {
            bool isActive = (string.Compare(filterByStatus, "active", true) == 0) ? true : false;
            var orders = _orderService.GetOrders(isActive, 1, 500);
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id)
        {
            try
            {
                var order = _orderService.GetOrderEditViewModel(id);
                return Json(order, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to get order: {0}", id);
                return this.JsonErrorResult("Error occured, unable to get order. We are fixing it.");
            }
        }

        [HttpPost]
        public JsonResult Edit(OrderSaveModel order)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return this.JsonErrorResult();
                }

                _orderService.Update(order);

                return this.JsonSuccessResult();
            }
            catch(Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to update order: {0}, {1}", order.Id);
                return this.JsonErrorResult("Error occured, unable to update order. We are fixing it.");
            }                
        }

        [HttpDelete]
        public JsonResult Deactivate(int id)
        {
            try
            {
                _orderService.Deactivate(id);

                return Json(new { Success = true}, JsonRequestBehavior.DenyGet);
            }
            catch(Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to deactivate order {0}", id);
                return this.JsonErrorResult("Error occured, unable to deactivate order. We are fixing it.");
            }
        }

        [HttpPost]
        public JsonResult Activate(int id)
        {
            try
            {
                _orderService.Activate(id);

                return this.JsonSuccessResult();
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to activate order {0}", id);
                return this.JsonErrorResult("Error occured, unable to activate order. We are fixing it.");
            }
        } 
    }
}
