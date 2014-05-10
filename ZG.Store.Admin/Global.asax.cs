using Castle.Facilities.Logging;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZG.Application.Installers;
using ZG.Common.Installers;
using ZG.Repository.Installers;
using ZG.Store.Admin.Plumbing;

namespace ZG.Store.Admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static object _initializerLock = new object();
        private static bool _isInitialized;
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();

            AddModelBinders();
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            NLog.LogManager.GetLogger("*").ErrorException("Unhandled error", ex);
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This(),
                                                        FromAssembly.Containing<CommonConcretesInstaller>(),
                                                        FromAssembly.Containing<RepositoriesInstaller>(),
                                                        FromAssembly.Containing<ServicesInstaller>());

            _container.AddFacility<LoggingFacility>(f => f.UseNLog());

            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory); 
        }

        private static void AddModelBinders()
        {
            //ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            //ModelBinders.Binders.Add(typeof(CheckoutDetails), new CheckoutDetailsModelBinder());
        }
    }
}
