using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tank.Model;

namespace Tank.ViewModel.Converters
{
    class WallConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is Wall))
                return Binding.DoNothing;

            return AppDomain.CurrentDomain.BaseDirectory + "Pictures\\wall" + ((Wall)value).Durability + ".png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
