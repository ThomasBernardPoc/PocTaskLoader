using System.Globalization;

namespace PocTaskLoader.Core.Commons.Converters;

internal class BoolToInvertedBoolValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(value is bool booleanValue && booleanValue);

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
