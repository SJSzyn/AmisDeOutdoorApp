using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using AmisDeOutdoorApp.Models;

namespace AmisDeOutdoorApp.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherModel closestWeatherData;
        public WeatherModel ClosestWeatherData
        {
            get { return closestWeatherData; }
            set
            {
                closestWeatherData = value;
                OnPropertyChanged();
            }
        }

        public WeatherViewModel()
        {
            FetchWeatherData();
        }

        private async void FetchWeatherData()
        {
            string apiUrl = "http://www.infoclimat.fr/public-api/gfs/json?_ll=45.16667,5.71667&_auth=VU8DFAd5AyFWe1JlBHJVfFQ8VGELfVVyVioBYgtjBHlUNl48AGUGYlQ8USwDLAU0WHVXMA4wUmwFYAFhWCpSLlU1A2cHZQNlVj5SMgQ8VX5UeFQpCzVVclYqAWQLeARgVClePgBlBnpUOVEwAzsFLlh0VzYONlJoBWUBZlgzUjVVNANjB2UDflYmUjYEMlUzVGRUYAtiVT9WNAEzCzcEZ1QyXjwAYQZ6VDxRNgM0BTRYbVc0DjJSYgV5AXlYTFJCVSsDJwcmAzRWf1ItBGFVP1Qz&_c=ea8f90362ab76b6b912d8ac5a71dce2a";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    JObject weatherJson = JObject.Parse(responseData);

                    DateTime now = DateTime.Now;
                    DateTime closestTime = DateTime.MinValue;
                    TimeSpan minDifference = TimeSpan.MaxValue;

                    foreach (var property in weatherJson.Properties())
                    {
                        if (DateTime.TryParseExact(property.Name, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
                        {
                            TimeSpan difference = (time - now).Duration();
                            if (difference < minDifference)
                            {
                                minDifference = difference;
                                closestTime = time;
                            }
                        }
                    }

                    if (closestTime != DateTime.MinValue)
                    {
                        var closestData = weatherJson[closestTime.ToString("yyyy-MM-dd HH:mm:ss")];
                        ClosestWeatherData = new WeatherModel
                        {
                            Time = closestTime,
                            Temperature = (double)closestData["temperature"]["sol"] - 273.15,
                            Humidity = (double)closestData["humidite"]["2m"],
                            Precipitation = (double)closestData["pluie"],
                            Wind = (double)closestData["vent_moyen"]["10m"]
                        };
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
