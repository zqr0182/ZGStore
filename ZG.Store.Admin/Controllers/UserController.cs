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
            var result = GetUsers(filterByStatus);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(List<UserViewModel> users, string filterByStatus)
        {
            return UpsertUsers(users, filterByStatus);
        }

        private JsonResult UpsertUsers(List<UserViewModel> users, string filterByStatus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                    return Json(new { Success = false, Errors = errors }, JsonRequestBehavior.DenyGet);
                }

                _userService.Upsert(users);
                var usersInDb = GetUsers(filterByStatus);

                return Json(new { Success = true, Users = usersInDb }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat(ex, "Failed to upsert users.");
                return Json(new { Success = false, Errors = new[] { "Error occured. Unable to upsert users. We are fixing it." } }, JsonRequestBehavior.DenyGet);
            }
        }

        private List<UserViewModel> GetUsers(string filterByStatus)
        {
            bool isActive = (string.Compare(filterByStatus, "active", true) == 0) ? true : false;

            return _userService.GetUsers(isActive).ToList();
        }
    }
}