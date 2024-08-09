using System;
using System.Globalization;
using System.Windows.Data;

namespace AmisDeOutdoorApp.Converters
{
    /// <summary>
    /// Converts temperature double values to strings of text
    /// </summary>
    public class TemperatureToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double temperature)
            {
                if (temperature > 35)
                {
                    return "Canicule : Alerte Rouge";
                }
                else if (temperature > 30)
                {
                    return "Chaleur forte";
                }
                else if (temperature > 25)
                {
                    return "Chaud";
                }
                else if (temperature > 20)
                {
                    return "Agréable";
                }
                else if (temperature > 15)
                {
                    return "Parfait";
                }
                else if (temperature > 10)
                {
                    return "Frais";
                }
                else if (temperature > 5)
                {
                    return "Froid";
                }
                else if (temperature > 0)
                {
                    return "Très froid";
                }
                else if (temperature > -5)
                {
                    return "Glacial";
                }
                else if (temperature > -10)
                {
                    return "Très glacial";
                }
                else
                {
                    return "Alert! Temperature extreme";
                }
            }

            return "Error de temperature";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
