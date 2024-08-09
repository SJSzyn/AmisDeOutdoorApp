using AmisDeOutdoorApp.Converters;
using AmisDeOutdoorApp.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmisDeOutdoorApp.Services
{
    public class MeteoAPI
    {
        public List<DayTemp> myFunc()
        {
            // Paris
            //double lon = 2.3488;
            //double lat = 48.85341;

            // Grenoble
            double lon = 5.71667;
            double lat = 45.166672;
            string longitude = lon.ToString().Replace(",", ".");
            string latitude = lat.ToString().Replace(",", ".");

            // Get data from server
            GetMeteo meteo = new GetMeteo();
            string responseFromServer = meteo.GetMeteoOnLL(latitude, longitude);


            // Convert response to Json Object
            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(responseFromServer);
            Console.WriteLine(jsonObject);

            // Convert Json object to List of DayTemp
            ConverterDatas converter = new ConverterDatas();
            List<DayTemp> dayTemps = converter.ConvertJsonToDays(jsonObject);

            Console.WriteLine();

            // Show Datas in console
            foreach (DayTemp respData in dayTemps)
            {
                if (respData.Hour == "02:00")
                {
                    Console.WriteLine($"Date: {respData.Day}");
                }

                // Convert object DayTemp to string
                string textResp = converter.ConvertDayTempToShow(respData);
                Console.WriteLine(textResp);
                if (respData.Hour == "23:00")
                {
                    Console.WriteLine();
                }
            }
            return dayTemps;
        }
    }
}