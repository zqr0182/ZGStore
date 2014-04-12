﻿using System.Web;
using System.Web.Optimization;

namespace ZG.Store.Admin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/App/lib/angular/angular-file-upload-shim.js"
                ,"~/App/lib/angular/angular.js"
                , "~/App/lib/angular/angular-route.js"
                , "~/App/lib/angular/angular-resource.js"
                , "~/App/lib/angular/angular-file-upload.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/storeAdminApp").Include(
                "~/App/js/storeAdminApp.js"
                , "~/App/js/controllers.js"
                , "~/App/js/editProductController.js"
                , "~/App/js/productListController.js"
                , "~/App/js/productCategoryListController.js"
                , "~/App/js/services.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
