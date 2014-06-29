using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC_DesignPattern.Models;

namespace MVC_DesignPattern.Controllers
{
    public class WeatherController : ApiController
    {
        private const string yahooWeatherUrl = "http://weather.yahooapis.com/forecastrss?w={0}&u=c";
        [HttpGet]
        public WeatherModels GetYahooWeather(string zipCode)
        {
            WeatherModels model = new WeatherModels();
            string weatherUrl = string.Format(yahooWeatherUrl, zipCode);

            return model;
        }
    }
}
