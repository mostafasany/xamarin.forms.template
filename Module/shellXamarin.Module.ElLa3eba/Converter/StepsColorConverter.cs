using System;
using System.Globalization;
using Xamarin.Forms;

namespace shellXamarin.Module.ElLa3eba.Converter
{
    public class StepsColorConverter: IValueConverter
    {
    

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool enabled = false;
            bool.TryParse(value.ToString(), out enabled);
            if (enabled)
                return Color.Green;
            else
                return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
