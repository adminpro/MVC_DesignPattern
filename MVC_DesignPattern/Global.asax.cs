using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Models;
using SqlDatabase.DbInitializer;
using Logger;
using Common;
namespace MVC_DesignPattern
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Init database if not exists
            //var context = new BaseContext();
            //var dataBaseInitializer = new DataBaseInitializer();
            //dataBaseInitializer.InitializeDatabase(context);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            var exception = ctx.Server.GetLastError();

            var errorInfo =
               "Source: " + exception.Source + Environment.NewLine +
               "Message: " + exception.Message + Environment.NewLine +
               "Stack trace: " + exception.StackTrace;
            ErrorLog.WriteLog(ctx.Request.Url.ToString(), errorInfo, Server.MapPath(Constants.LogPath));
        }
    }
}