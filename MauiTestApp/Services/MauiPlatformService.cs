namespace MauiTestApp.Services;

public class MauiPlatformService : IPlatformService
{
    public string DeviceManufacturer => DeviceInfo.Manufacturer;
    public string DeviceModel => DeviceInfo.Model;
    public string OsVersion => $"{DeviceInfo.Platform} {DeviceInfo.VersionString}";
    public string DeviceIdiom => DeviceInfo.Idiom.ToString();
    public string DevicePlatform => DeviceInfo.Platform.ToString();

    public string CheckConnectivity()
    {
        try
        {
            var access = Connectivity.Current.NetworkAccess;
            var profiles = Connectivity.Current.ConnectionProfiles;
            var profileStr = string.Join(", ", profiles);
            return $"{access} ({profileStr})";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public async Task CopyToClipboard(string text)
    {
        await Clipboard.Default.SetTextAsync(text);
    }

    public async Task<string> PasteFromClipboard()
    {
        try
        {
            var text = await Clipboard.Default.GetTextAsync();
            return text ?? "(empty)";
        }
        catch (Exception ex)
        {
            return $"Not supported: {ex.Message}";
        }
    }

    public async Task ShareText(string text, string title)
    {
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = title
        });
    }

    public async Task<string> GetLocation()
    {
        try
        {
            var location = await Geolocation.Default.GetLocationAsync(
                new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)));

            return location is not null
                ? $"Lat: {location.Latitude:F4}, Lon: {location.Longitude:F4}"
                : "Location unavailable";
        }
        catch (FeatureNotSupportedException)
        {
            return "Not supported on this device";
        }
        catch (PermissionException)
        {
            return "Permission denied";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public void Vibrate(int milliseconds)
    {
        try
        {
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(milliseconds));
        }
        catch (FeatureNotSupportedException)
        {
            // silently ignore
        }
    }

    public async Task<string> ToggleFlashlight()
    {
        try
        {
            await Flashlight.Default.TurnOnAsync();
            await Task.Delay(2000);
            await Flashlight.Default.TurnOffAsync();
            return "Flashlight toggled";
        }
        catch (Exception ex)
        {
            return $"Flashlight error: {ex.Message}";
        }
    }

    public void SavePreference(string key, string value)
    {
        Preferences.Default.Set(key, value);
    }

    public string ReadPreference(string key)
    {
        return Preferences.Default.Get(key, "(not set)");
    }
}
