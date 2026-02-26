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
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                    return "Location permission denied";
            }

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
            var status = await Permissions.CheckStatusAsync<Permissions.Flashlight>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Flashlight>();
                if (status != PermissionStatus.Granted)
                    return "Flashlight permission denied";
            }

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

    public async Task<CameraResult> TakePhotoAsync()
    {
        try
        {
            if (!MediaPicker.Default.IsCaptureSupported)
                return new CameraResult { Success = false, Message = "Camera not supported on this device" };

            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                    return new CameraResult { Success = false, Message = "Camera permission denied" };
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo is null)
                return new CameraResult { Success = false, Message = "Photo capture cancelled" };

            using var stream = await photo.OpenReadAsync();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var base64 = Convert.ToBase64String(memoryStream.ToArray());

            return new CameraResult
            {
                Success = true,
                Message = $"Photo captured: {photo.FileName}",
                ImageBase64 = base64
            };
        }
        catch (FeatureNotSupportedException)
        {
            return new CameraResult { Success = false, Message = "Camera not supported on this device" };
        }
        catch (PermissionException)
        {
            return new CameraResult { Success = false, Message = "Camera permission denied" };
        }
        catch (Exception ex)
        {
            return new CameraResult { Success = false, Message = $"Camera error: {ex.Message}" };
        }
    }
}
