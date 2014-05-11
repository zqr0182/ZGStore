using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZG.Application;
using ZG.Common;
using ZG.Domain.DTO;
using ZG.Domain.Models;

namespace ZG.Store.Admin.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        readonly ILogger _logger;

        public UserController(IUserService userService, ILogger logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public JsonResult List(string filterByStatus)
        {
            bool isActive = (string.Compare(filterByStatus, "active", true) == 0) ? true : false;

            var result = _userService.GetUsers(isActive).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<UserViewModel> users)
        {
            return UpsertUsers(users);
        }

        private JsonResult UpsertUsers(List<UserViewModel> users)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                _userService.Upsert(users);

                return Json(new { Success = true }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert users.");
                return Json(new { Success = false, Errors = new[] { "Error occured. Unable to upsert users. We are fixing it." } }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}