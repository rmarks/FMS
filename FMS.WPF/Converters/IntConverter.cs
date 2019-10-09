using System;
using System.Globalization;
using System.Windows.Data;

namespace FMS.WPF.Converters
{
    public class IntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int && (int)value == 0)
                return string.Empty;
            else
                return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int temp_int;
            return Int32.TryParse(value as string, out temp_int) ? temp_int : 0;
        }
    }
}
