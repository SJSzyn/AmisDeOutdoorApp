using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using AmisDeOutdoorApp.Models;

namespace AmisDeOutdoorApp.ViewModels
{
    /// <summary>
    /// ViewModel to handle weather data fetching and provide it to the view.
    /// </summary>
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherModel closestWeatherData;

        /// <summary>
        /// Gets or sets the weather data closest to the current time.
        /// </summary>
        public WeatherModel ClosestWeatherData
        {
            get { return closestWeatherData; }
            set
            {
                closestWeatherData = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherViewModel"/> class and fetches weather data.
        /// </summary>
        public WeatherViewModel()
        {
            FetchWeatherData();
        }

        /// <summary>
        /// Fetches weather data from the API and updates the <see cref="ClosestWeatherData"/> property.
        /// </summary>
        private async void FetchWeatherData()
        {
            string apiUrl = "http://www.infoclimat.fr/public-api/gfs/json?_ll=45.16667,5.71667&_auth=VU8DFAd5AyFWe1JlBHJVfFQ8VGELfVVyVioBYgtjBHlUNl48AGUGYlQ8USwDLAU0WHVXMA4wUmwFYAFhWCpSLlU1A2cHZQNlVj5SMgQ8VX5UeFQpCzVVclYqAWQLeARgVClePgBlBnpUOVEwAzsFLlh0VzYONlJoBWUBZlgzUjVVNANjB2UDflYmUjYEMlUzVGRUYAtiVT9WNAEzCzcEZ1QyXjwAYQZ6VDxRNgM0BTRYbVc0DjJSYgV5AXlYTFJCVSsDJwcmAzRWf1ItBGFVP1Qz&_c=ea8f90362ab76b6b912d8ac5a71dce2a";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

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
                            Temperature = ConvertKelvinToCelsius((double)closestData["temperature"]["sol"]),
                            Humidity = (double)closestData["humidite"]["2m"],
                            Precipitation = (double)closestData["pluie"],
                            Wind = (double)closestData["vent_moyen"]["10m"],
                            Nebulosity = (double)closestData["nebulosite"]["totale"]
                        };
                    }
                    else
                    {
                        throw new Exception("No valid time found in the weather data.");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Converts temperature from Kelvin to Celsius.
        /// </summary>
        /// <param name="kelvin">The temperature in Kelvin.</param>
        /// <returns>The temperature in Celsius.</returns>
        private double ConvertKelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="name">The name of the property that changed.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
