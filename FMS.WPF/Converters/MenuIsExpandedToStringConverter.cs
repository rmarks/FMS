using System;
using System.Globalization;
using System.Windows.Data;

namespace FMS.WPF.Converters
{
    public class MenuIsExpandedToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a String");

            if ((bool)value)
            {
                return "Peida menüü";
            }
            return "Näita menüüd";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
