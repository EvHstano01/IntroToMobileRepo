using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MobileAppProject.Converters
{
    public class BoolToFavouriteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isFav && isFav)
                return "★";
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
