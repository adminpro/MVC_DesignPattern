using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MVC_DesignPattern.Filters;

namespace MVC_DesignPattern
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
