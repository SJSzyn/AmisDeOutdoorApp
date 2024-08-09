using System;

namespace AmisDeOutdoorApp.Models
{
    /// <summary>
    /// Represents weather data for a specific time.
    /// </summary>
    public class WeatherModel
    {
        private DateTime time;
        private double temperature;
        private double humidity;
        private double precipitation;
        private double wind;
        private double nebulosity;

        /// <summary>
        /// Gets or sets the time of the weather data.
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set
            {
                if (value == default(DateTime))
                    throw new ArgumentException("Time cannot be the default value.", nameof(value));
                time = value;
            }
        }

        /// <summary>
        /// Gets or sets the temperature in Celsius.
        /// </summary>
        public double Temperature
        {
            get { return temperature; }
            set
            {
                if (value < -273.15)
                    throw new ArgumentOutOfRangeException(nameof(value), "Temperature cannot be below absolute zero.");
                temperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the humidity as a percentage.
        /// </summary>
        public double Humidity
        {
            get { return humidity; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "Humidity must be between 0 and 100.");
                humidity = value;
            }
        }

        /// <summary>
        /// Gets or sets the precipitation in millimeters.
        /// </summary>
        public double Precipitation
        {
            get { return precipitation; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Precipitation cannot be negative.");
                precipitation = value;
            }
        }

        /// <summary>
        /// Gets or sets the wind speed in meters per second.
        /// </summary>
        public double Wind
        {
            get { return wind; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Wind speed cannot be negative.");
                wind = value;
            }
        }

        /// <summary>
        /// Gets or sets the nebulosity.
        /// </summary>
        public double Nebulosity
        {
            get { return nebulosity; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Nebulosity cannot be negative.");
                nebulosity = value;
            }
        }
    }
}
