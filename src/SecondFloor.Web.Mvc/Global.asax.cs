using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SecondFloor.RepositoryEF;
using SecondFloor.RepositoryEF.Migrations;

namespace SecondFloor.Web.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Inicializacao do Banco de dados e migração caso mudança de modelo
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AnuncianteContext, AnuncianteModelConfiguration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
