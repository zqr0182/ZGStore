using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZG.Common;

namespace ZG.Store.Admin.App_Code
{
    public static class PathUtil
    {
        public static string GetProductImageDirectory(int productId)
        {
            return HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}", Constants.ProductImageDirectory, productId));
        }
    }
}