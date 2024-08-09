using System;

namespace AmisDeOutdoorApp.Models
{
    [Serializable]
    public class DayTemp
    {
        public string Day { get; set; }
        public string Hour { get; set; }
        public string WeekDay { get; set; }
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public string Emoji { get; set; }
    }
}
