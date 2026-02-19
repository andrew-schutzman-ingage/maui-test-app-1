using System.Globalization;

namespace MauiTestApp.Converters;

/// <summary>
/// Converts a 0-100 slider value to a 0.0-1.0 progress value for ProgressBar.
/// </summary>
public class DivideBy100Converter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double d)
            return d / 100.0;
        return 0.0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double d)
            return d * 100.0;
        return 0.0;
    }
}
