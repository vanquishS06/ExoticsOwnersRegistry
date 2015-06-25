using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;

namespace ExoticsOwnersRegistry.Models
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // TODO this is here from demo purposes . Should be moved for production
            // Set dbase initializer
            Database.SetInitializer<ExoticsOwnersRegistryContext>(new RegistryDataContextInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
