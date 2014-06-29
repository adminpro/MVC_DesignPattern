using System.Web;
using System.Web.Mvc;
using System.Web.Http.Filters;
using MVC_DesignPattern.Filters;

namespace MVC_DesignPattern
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            filters.Add(new CompressAttribute());
            filters.Add(new RestrictTimeRequestAttribute());
        }
    }
}