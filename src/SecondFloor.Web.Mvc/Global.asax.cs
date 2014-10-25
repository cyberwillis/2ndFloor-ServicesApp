using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
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
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AnuncianteContext, AnuncianteModelConfiguration>());
            Database.SetInitializer(new AnuncianteModelConfiguration());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Fix sugerido por
        //http://brockallen.com/2012/10/22/dealing-with-session-token-exceptions-with-wif-in-asp-net/
        void Application_OnError()
        {
            var ex = Context.Error;
            if (ex is SecurityTokenException)
            {
                Context.ClearError();
                if (FederatedAuthentication.SessionAuthenticationModule != null)
                {
                    FederatedAuthentication.SessionAuthenticationModule.SignOut();
                }
                Response.Redirect("~/");
            }
        }

        
    }
}
