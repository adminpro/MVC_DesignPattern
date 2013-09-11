using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DesignPattern.ViewModel;

namespace MVC_DesignPattern.Controllers
{
    public class Base64Controller : BaseController
    {
        //
        // GET: /Base64/
        [HttpGet]
        public ActionResult Index()
        {
            VMBase64 vmIndex = new VMBase64();
            ViewBag.Base64ConvertType = EnumToSelectList<Base64ConvertType, byte>(vmIndex.Type);
            return View(vmIndex);
        }
        [HttpPost]
        public ActionResult Index(VMBase64 vmIndex)
        {
            switch (vmIndex.Type)
            {
                case Base64ConvertType.StringToBase64:
                    return RedirectToAction("Encode", vmIndex);
                case Base64ConvertType.Base64ToString:
                    return RedirectToAction("Decode", vmIndex);
                default:
                    return View(vmIndex);
            }
        }

        [HttpGet]
        public ActionResult Encode()
        {
            return View(new VMBase64());
        }
        [HttpPost]
        public ActionResult Encode(VMBase64 vmEncode)
        {
            ModelState.Remove("Destination");
            vmEncode.Destination = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(vmEncode.Source));
            return View(vmEncode);
        }
        [HttpGet]
        public ActionResult Decode()
        {
            VMBase64 vmEncode = new VMBase64
            {
                Type = Base64ConvertType.Base64ToString
            };
            return View(vmEncode);
        }
        [HttpPost]
        public ActionResult Decode(VMBase64 vmDecode)
        {
            ModelState.Remove("Destination");
            vmDecode.Destination = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(vmDecode.Source));
            return View(vmDecode);
        }

        private SelectList EnumToSelectList<T, dataType>(T objVal)
        {
            var listEnumValues = (from T c in Enum.GetValues(typeof(T))
                                  select new { 
                                      Key = c,
                                      Value = c.ToString()
                                  });
            return new SelectList(listEnumValues, "Key", "Value", objVal);
        }
    }
}
