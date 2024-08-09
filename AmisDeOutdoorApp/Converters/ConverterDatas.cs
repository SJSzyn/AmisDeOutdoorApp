using AmisDeOutdoorApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmisDeOutdoorApp.Converters
{
    public class ConverterDatas
    {

        public List<DayTemp> ConvertJsonToDays(JObject jsonObject)
        {
            var dayTemps = new List<DayTemp>();

            foreach (var kvp in jsonObject)
            {
                if (DateTime.TryParse(kvp.Key, out DateTime date))
                {
                    var day = date.ToString("dd-MM-yyyy");
                    var hour = date.ToString("HH:mm");
                    var weekDay = date.DayOfWeek.ToString();

                    var data = kvp.Value as JObject;
                    if (data != null)
                    {
                        double temp = data["temperature"]?["2m"]?.Value<double>() ?? 0;
                        temp = temp - 273.15;
                        double pressure = data["pression"]?["niveau_de_la_mer"]?.Value<double>() ?? 0;
                        pressure = pressure / 100;
                        double humidity = data["humidite"]?["2m"]?.Value<double>() ?? 0;
                        double nebulosiete = data["nebulosite"]?["totale"]?.Value<double>() ?? 0;

                        string emoji;
                        if (nebulosiete == 0)
                        {
                            emoji = "☀️";
                        }
                        else if (nebulosiete < 50)
                        {
                            emoji = "☁️";
                        }
                        else
                        {
                            emoji = "🌧️";
                        }
                        
                        dayTemps.Add(new DayTemp
                        {
                            Day = day,
                            Hour = hour,
                            WeekDay = weekDay,
                            Temp = temp,
                            Pressure = pressure,
                            Humidity = humidity,
                            Emoji = emoji
                        });
                    }
                }
            }
            return dayTemps;
        }

        public string ConvertDayTempToShow(DayTemp dayTemp)
        {
            return $"{dayTemp.Hour} Temp={dayTemp.Temp}°C, Pressure={dayTemp.Pressure}hPa, Humidity={dayTemp.Humidity}%";
        }

    }
}
