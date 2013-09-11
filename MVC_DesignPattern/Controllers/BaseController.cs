using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_DesignPattern.Controllers
{
    [HandleError(ExceptionType=typeof(HttpNotFoundResult), View="Error")]
    public class BaseController: Controller
    {
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    if (this.GetType() != typeof(ErrorController))
        //    {
        //        IController errorController = new ErrorController();
        //        var errorRoute = new RouteData();
        //        errorRoute.Values.Add("controller", "Error");
        //        errorRoute.Values.Add("action", "BadRequest");
        //        errorRoute.Values.Add("errMsg", "Page could not be found.");
        //        errorRoute.Values.Add("url", HttpContext.Request.Url.OriginalString);
        //        errorController.Execute(new RequestContext(
        //             HttpContext, errorRoute));
        //    }
        //    else
        //        base.HandleUnknownAction(actionName);
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.IsAjaxRequest())
            {
                filterContext.Result = new HttpNotFoundResult("Current controller does not support ajax request.");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}