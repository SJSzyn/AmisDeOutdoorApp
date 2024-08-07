using System;

namespace AmisDeOutdoorApp.Models
{
    public class WeatherModel
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Precipitation { get; set; }
        public double Wind { get; set; }

    }
}
