using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tank.Model;

namespace Tank.ViewModel.Converters
{
    class DirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is Direction))
                return Binding.DoNothing;

            switch((Direction) value)
            {
                case Direction.UP:
                    return "180";
                case Direction.RIGHT:
                    return "270";
                case Direction.DOWN:
                    return "0";
                case Direction.LEFT:
                    return "90";

                default:
                    return 45;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
