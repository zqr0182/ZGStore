using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZG.Store.Presentation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Products", "", new { controller = "Product", action = "List", category = (string)null, page = 1 });
            routes.MapRoute("ProductsByPage", "page{page}", new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" });
            routes.MapRoute("ProductsByCategory", "{category}", new { controller = "Product", action = "List", page = 1 });
            routes.MapRoute("ProductsByCategoryAndPage", "{category}/Page{page}", new { controller = "Product", action = "List" }, new { page = @"\d+" });
            routes.MapRoute("ProductDetails", "product/{id}", new { controller = "Product", action = "Details" }, new { id = @"\d+" });

            routes.MapRoute("AdminProductEdit", "admin/product/{id}", new { controller = "ProductAdmin", action = "Edit"}, new { id = @"\d+" });
            routes.MapRoute("AdminProductDelete", "admin/product/delete", new { controller = "ProductAdmin", action = "Delete" });
            routes.MapRoute("AdminProducts", "admin/products", new { controller = "ProductAdmin", action = "List", category = (string)null, page = 1 });
            routes.MapRoute("AdminProductsByPage", "admin/products/page{page}", new { controller = "ProductAdmin", action = "List", category = (string)null }, new { page = @"\d+" });
            routes.MapRoute("AdminProductsByCategory", "admin/products/{category}", new { controller = "ProductAdmin", action = "List", page = 1 });
            routes.MapRoute("AdminProductsByCategoryAndPage", "admin/products/{category}/Page{page}", new { controller = "ProductAdmin", action = "List" }, new { page = @"\d+" });

            routes.MapRoute("EverythingElse", "{controller}/{action}");
        }
    }
}