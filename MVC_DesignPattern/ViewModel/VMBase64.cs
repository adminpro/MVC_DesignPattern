using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_DesignPattern.ViewModel
{
    [ValidateInput(false)]
    public class VMBase64
    {
        public VMBase64()
        {
            this.Type = Base64ConvertType.StringToBase64;
        }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Source { get; set; }
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Destination { get; set; }
        public Base64ConvertType Type { get; set; }
    }

    public enum Base64ConvertType : byte
    {
        StringToBase64 = 1,
        Base64ToString = 2
    }
}