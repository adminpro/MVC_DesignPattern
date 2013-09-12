using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DesignPattern.Filters;

namespace MVC_DesignPattern.Controllers
{
    public class HomeController : Controller
    {
        [RestrictTimeRequest(Name="Index", Seconds=5, Message = "Please don't refresh quickly...")]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        [RestrictTimeRequest(Name = "About", Seconds = 5, Message = "Please don't refresh quickly...")]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [RestrictTimeRequest(Name = "Contact", Seconds = 5, Message = "Please don't refresh quickly...")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult JSTools()
        {
            return View();
        }
    }
}
