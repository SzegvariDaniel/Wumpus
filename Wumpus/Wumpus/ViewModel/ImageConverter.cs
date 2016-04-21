using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wumpus.ViewModel
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is String))
                return Binding.DoNothing;

            if (((String)value).Equals(""))
                return "";

            return AppDomain.CurrentDomain.BaseDirectory + "Pictures\\" + (String)value + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
