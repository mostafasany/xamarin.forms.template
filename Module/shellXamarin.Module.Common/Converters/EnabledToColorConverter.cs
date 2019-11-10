using System;
using System.Globalization;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.Converters
{
    public class EnabledToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool enabled = false;
            bool.TryParse(value.ToString(), out enabled);
            if (enabled)
                return Color.White;
            else
                return Color.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

