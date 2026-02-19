using System.Globalization;

namespace MauiTestApp.Converters;

/// <summary>
/// Extracts the first character of a string. Used for avatar-style initials in the data list.
/// </summary>
public class FirstCharConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string s && s.Length > 0)
            return s[0].ToString();
        return "?";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
