using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Caching;
using System.Net;
using System.Net.Http;

namespace MVC_DesignPattern.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RestrictTimeRequestAttribute: ActionFilterAttribute, IActionFilter
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int Seconds { get; set; }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //System.Web.Mvc.ActionExecutingContext 
            var cacheKey = string.Concat(this.Name, "-", HttpContext.Current.Request.UserHostAddress);
            bool allowExecute = false;

            if (HttpRuntime.Cache[cacheKey]==null)
            {
                HttpRuntime.Cache.Add(cacheKey
                    , true
                    , null
                    , DateTime.Now.AddSeconds(this.Seconds)
                    , Cache.NoSlidingExpiration
                    , CacheItemPriority.Low
                    , null
                );
                allowExecute = true;
            }

            if (!allowExecute)
            {
                //if (String.IsNullOrEmpty(Message))
                //    Message = "You may only perform this action every {n} seconds.";

                //actionContext.ControllerContext
                //// see 409 - http://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html
                actionContext.Response.Content = new StringContent(this.Message);
                actionContext.Response.StatusCode = HttpStatusCode.Conflict;
            }
            else
                base.OnActionExecuting(actionContext);
        }
    }
}