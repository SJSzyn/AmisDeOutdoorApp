using System;
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
                    imagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Sun_symbol_%28bold%29.svg/1024px-Sun_symbol_%28bold%29.svg.png";
                }
                else if (nebulosity > 0 && nebulosity <= 50)
                {
                    imagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Sun_symbol_%28bold%29.svg/1024px-Sun_symbol_%28bold%29.svg.png";
                }
                else
                {
                    imagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Sun_symbol_%28bold%29.svg/1024px-Sun_symbol_%28bold%29.svg.png";
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
