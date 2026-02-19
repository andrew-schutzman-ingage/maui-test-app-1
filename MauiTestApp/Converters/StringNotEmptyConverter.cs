using System.Globalization;

namespace MauiTestApp.Converters;

/// <summary>
/// Returns true if the string is not null or empty. Used for IsVisible bindings.
/// </summary>
public class StringNotEmptyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is string s && !string.IsNullOrEmpty(s);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
