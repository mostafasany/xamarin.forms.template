using System;
using System.Globalization;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.Connverters
{
    public class MandatoryToColorConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool mandatory = false;
            bool.TryParse(value.ToString(), out mandatory);
            if (mandatory)
                return Color.Red;
            else
                return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

