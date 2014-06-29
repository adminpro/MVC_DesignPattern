using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DesignPattern.Filters;

namespace MVC_DesignPattern.Controllers
{
    public class LessionLearnController : Controller
    {
        [RestrictTimeRequest(Name="Index", Seconds=5, Message = "Please don't refresh quickly...")]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        [RestrictTimeRequest(Name = "TopicGroup", Seconds = 5, Message = "Please don't refresh quickly...")]
        public ActionResult TopicGroup()
        {
            ViewBag.Message = "Lession learn: TopicGroup.";

            return View();
        }
        [RestrictTimeRequest(Name = "Chapter", Seconds = 5, Message = "Please don't refresh quickly...")]
        public ActionResult Chapter()
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
