using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZG.Store.Admin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

#if DEBUG
            routes.IgnoreRoute("{*browserlink}", new { browserlink = @".*/arterySignalR/ping" });
#endif
            routes.MapRoute(
                name: "ProductList",
                url: "product/list/{filterByStatus}",
                defaults: new { controller = "Product", action = "List" }
            );

            routes.MapRoute(
                name: "ProductCategoryList",
                url: "productcategory/list/{filterByStatus}",
                defaults: new { controller = "ProductCategory", action = "List" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteProductImage",
                url: "{controller}/{action}/{imageName}/{prodId}",
                defaults: new { controller = "Product", action = "DeleteImage"}
            );
        }
    }
}
