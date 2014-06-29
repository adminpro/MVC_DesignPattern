using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DesignPattern.Models
{
    public class WeatherModels
    {
        public int ZipCode { get; set; }
        public DateTime LastUpdate { get; set; }
        public Location Location { get; set; }
        public Units Units { get; set; }
        public Wind Wind { get; set; }
        public Atmosphere Atmosphere { get; set; }
        public Item Item { get; set; }
    }

    public class Location
    {
        //city="Vung Tau" region="" country="Vietnam"
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }

    public class Units
    {
        //temperature="C" distance="km" pressure="mb" speed="km/h"
        public string Temperature { get; set; }
        public string Distance { get; set; }
        public string Pressure { get; set; }
        public string Speed { get; set; }
    }

    public class Wind
    {
        //chill="30" direction="0" speed="4.83"
        public string Child { get; set; }
        public string Direction { get; set; }
        public string Speed { get; set; }
    }

    public class Atmosphere
    {
        //humidity="70" visibility="8" pressure="982.05" rising="0"
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Pressure { get; set; }
        public string Rising { get; set; }
    }

    public class Item
    {
        public string Title { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}