using CMS.API.App_Start;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // LightInject initially configure
            var container = new ServiceContainer();
            container.RegisterApiControllers();
            ApplicationConfig.Bootstrap(container);
            container.EnableWebApi(GlobalConfiguration.Configuration);

            //Initialize data store
            DataStoreConfig.Initialize();
        }
    }
}
