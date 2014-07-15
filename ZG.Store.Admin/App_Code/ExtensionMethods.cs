using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZG.Store.Admin.App_Code
{
    public static class ExtensionMethods
    {
        public static JsonResult JsonErrorResult(this Controller controller)
        {
            if (!controller.ModelState.IsValid)
            {
                var errors = controller.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                return new JsonResult() { Data = new { Success = false, Errors = errors }, JsonRequestBehavior = JsonRequestBehavior.DenyGet };
            }
            else
            {
                return null;
            }
        }

        public static JsonResult JsonSuccessResult(this Controller controller)
        {
            return new JsonResult() { Data = new { Success = true}, JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        }
    }
}