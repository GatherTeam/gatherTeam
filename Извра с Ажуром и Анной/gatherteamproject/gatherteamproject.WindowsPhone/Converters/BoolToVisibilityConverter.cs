using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace gatherteamproject.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibility = (Visibility)value;

            return visibility == Visibility.Visible;
        }
    }
}
