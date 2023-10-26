using System;
using System.Globalization;
using Xamarin.Forms;

namespace FeedBag
{
    public class IsNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valuesIn = value?.ToString();

            return string.IsNullOrWhiteSpace(valuesIn);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

