﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace AmisDeOutdoorApp.Converters
{
    public class NebulosityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double nebulosity)
            {
                string imagePath;

                if (nebulosity <= 0)
                {
                    imagePath = "https://upload.wikimedia.org/wikipedia/commons/d/df/RP_logo_variation.png";
                }
                else if (nebulosity > 0 && nebulosity <= 50)
                {
                    imagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f8/Antu_weather-clouds.svg/480px-Antu_weather-clouds.svg.png";
                }
                else
                {
                    imagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Weather-violent-storm.svg/480px-Weather-violent-storm.svg.png";
                }

                return new BitmapImage(new Uri(imagePath));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
