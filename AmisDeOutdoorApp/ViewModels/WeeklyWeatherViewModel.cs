using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmisDeOutdoorApp.Models;
using AmisDeOutdoorApp.Services;

namespace AmisDeOutdoorApp.ViewModels
{
    public class WeeklyWeatherViewModel
    {
        private ObservableCollection<DayTemp> _weeklyWeather;
        public ObservableCollection<DayTemp> WeeklyWeather
        { 
            get { return _weeklyWeather; } 
            set{
                _weeklyWeather = value;
            } 
        }

        public WeeklyWeatherViewModel()
        {
            LoadWeatherData();
        }

        private void LoadWeatherData()
        {
            //API
            MeteoAPI meteoAPI = new MeteoAPI();
            List<DayTemp> dayTempArray = meteoAPI.myFunc();

            WeeklyWeather = new ObservableCollection<DayTemp>(dayTempArray);
        }
    }
}
