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
using System.Collections;
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
            FilterConfig.RegisterHttpFilters(GlobalConfiguration.Configuration.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            //Set default language for page
            string currentLanguage = Utils.AppSettings.GetValue(Constants.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(currentLanguage);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(currentLanguage);
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

        //Implement IDisposable
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            var keys = new ArrayList(HttpContext.Current.Items.Keys);

            foreach (var key in keys)
            {
                var disposable = HttpContext.Current.Items[key] as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                    HttpContext.Current.Items[key] = null;
                }
            }
        }
    }
}