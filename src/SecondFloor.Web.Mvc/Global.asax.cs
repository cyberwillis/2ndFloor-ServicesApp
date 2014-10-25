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
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AnuncianteContext, AnuncianteModelConfiguration>());
            Database.SetInitializer(new AnuncianteModelConfiguration());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /*protected void Application_BeginRequest()
        {

        }

        protected void Application_AuthenticateEndRequest()
        {
            //TODO: authenticate a credential (if presentaut) or cookie, set principal, WindowsAuthentication, FormsAuthentication, WSFederation
        }

        protected void Application_PostAuthenticateRequest()
        {
            //TODO: Add Claims para principal, roles ou outro claim arbitrario
        }

        protected void Application_AuthorizeRequest()
        {
            //TODO: determinar se o usuario esta vlaidado para acessar o recurrso
        }

        protected void Application_EndRequest()
        {
            //TODO: errors codes, post processing, redirect, login novamente
        }*/
    }
}
