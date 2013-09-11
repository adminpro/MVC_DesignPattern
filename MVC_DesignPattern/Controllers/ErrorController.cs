using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DesignPattern.ViewModel;

namespace MVC_DesignPattern.Controllers
{
    public class ErrorController : BaseController
    {
        //
        // GET: /Error/

        public ActionResult Index(string errMsg, string url)
        {
            return View(new VMError { Message = errMsg, Url = url });
        }

        public ActionResult BadRequest(string errMsg, string url)
        {
            return View(new VMError { Code = 404, Message = errMsg, Url = url });
        }
    }
}
