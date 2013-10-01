using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.IO.Compression;

namespace MVC_DesignPattern.Filters
{
    public class CompressAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            // Analyze the list of acceptable encodings
            var preferredEncoding = GetPreferredEncoding(HttpContext.Current.Request);

            // Compress the response accordingly
            var response = HttpContext.Current.Response;
            response.AppendHeader("Content-encoding", preferredEncoding.ToString());

            if (preferredEncoding == CompressionScheme.Gzip)
            {
                response.Filter = new GZipStream(
                  response.Filter, CompressionMode.Compress);
            }

            if (preferredEncoding == CompressionScheme.Deflate)
            {
                response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
            }
            return;
            //base.OnActionExecuting(actionContext);
        }

        static CompressionScheme GetPreferredEncoding(HttpRequest request)
        {
            var acceptableEncoding = request.Headers["Accept-Encoding"];
            //acceptableEncoding = SortEncodings(acceptableEncoding);

            // Get the preferred encoding format 
            if (acceptableEncoding.Contains("gzip"))
                return CompressionScheme.Gzip;
            if (acceptableEncoding.Contains("deflate"))
                return CompressionScheme.Deflate;

            return CompressionScheme.Identity;
        }

        //static String SortEncodings(string header)
        //{
        //    // Omitted for brevity
        //}
    }
    enum CompressionScheme
    {
        Gzip = 0,
        Deflate=1,
        Identity=2
    }
}