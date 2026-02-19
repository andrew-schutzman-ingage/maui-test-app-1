using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiTestApp.ViewModels;

/// <summary>
/// ViewModel for the Platform Features demo.
/// Demonstrates MAUI's cross-platform device and platform API abstractions.
/// </summary>
public partial class PlatformViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _deviceManufacturer = string.Empty;

    [ObservableProperty]
    private string _deviceModel = string.Empty;

    [ObservableProperty]
    private string _osVersion = string.Empty;

    [ObservableProperty]
    private string _deviceIdiom = string.Empty;

    [ObservableProperty]
    private string _devicePlatform = string.Empty;

    [ObservableProperty]
    private string _connectivityStatus = "Tap to check";

    [ObservableProperty]
    private string _clipboardText = string.Empty;

    [ObservableProperty]
    private string _locationText = "Tap to get location";

    [ObservableProperty]
    private string _preferenceValue = string.Empty;

    [ObservableProperty]
    private string _preferenceKey = "demo_key";

    [ObservableProperty]
    private string _preferenceInput = string.Empty;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public PlatformViewModel()
    {
        Title = "Platform Features";
        LoadDeviceInfo();
    }

    private void LoadDeviceInfo()
    {
        DeviceManufacturer = DeviceInfo.Manufacturer;
        DeviceModel = DeviceInfo.Model;
        OsVersion = $"{DeviceInfo.Platform} {DeviceInfo.VersionString}";
        DeviceIdiom = DeviceInfo.Idiom.ToString();
        DevicePlatform = DeviceInfo.Platform.ToString();
    }

    [RelayCommand]
    private void CheckConnectivity()
    {
        try
        {
            var access = Connectivity.Current.NetworkAccess;
            var profiles = Connectivity.Current.ConnectionProfiles;
            var profileStr = string.Join(", ", profiles);
            ConnectivityStatus = $"{access} ({profileStr})";
        }
        catch (Exception ex)
        {
            ConnectivityStatus = $"Error: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task CopyToClipboard()
    {
        try
        {
            await Clipboard.Default.SetTextAsync("Hello from MAUI! 🎉");
            StatusMessage = "Copied to clipboard!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Not supported: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task PasteFromClipboard()
    {
        try
        {
            var text = await Clipboard.Default.GetTextAsync();
            ClipboardText = text ?? "(empty)";
        }
        catch (Exception ex)
        {
            ClipboardText = $"Not supported: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task ShareText()
    {
        try
        {
            await Share.Default.RequestAsync(new ShareTextRequest
            {
                Text = "Check out this MAUI Feature Showcase app!",
                Title = "Share from MAUI"
            });
        }
        catch (Exception ex)
        {
            StatusMessage = $"Not supported: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task GetLocation()
    {
        try
        {
            LocationText = "Getting location...";
            var location = await Geolocation.Default.GetLocationAsync(
                new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)));

            LocationText = location is not null
                ? $"Lat: {location.Latitude:F4}, Lon: {location.Longitude:F4}"
                : "Location unavailable";
        }
        catch (FeatureNotSupportedException)
        {
            LocationText = "Not supported on this device";
        }
        catch (PermissionException)
        {
            LocationText = "Permission denied";
        }
        catch (Exception ex)
        {
            LocationText = $"Error: {ex.Message}";
        }
    }

    [RelayCommand]
    private void Vibrate()
    {
        try
        {
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
            StatusMessage = "Vibrated!";
        }
        catch (FeatureNotSupportedException)
        {
            StatusMessage = "Vibration not supported on this device";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task ToggleFlashlight()
    {
        try
        {
            if (Flashlight.Default.IsSupported)
            {
                await Flashlight.Default.TurnOnAsync();
                StatusMessage = "Flashlight toggled";
                await Task.Delay(2000);
                await Flashlight.Default.TurnOffAsync();
            }
            else
            {
                StatusMessage = "Flashlight not supported on this device";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Flashlight error: {ex.Message}";
        }
    }

    [RelayCommand]
    private void SavePreference()
    {
        try
        {
            Preferences.Default.Set(PreferenceKey, PreferenceInput);
            StatusMessage = $"Saved '{PreferenceInput}' to key '{PreferenceKey}'";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    [RelayCommand]
    private void ReadPreference()
    {
        try
        {
            PreferenceValue = Preferences.Default.Get(PreferenceKey, "(not set)");
        }
        catch (Exception ex)
        {
            PreferenceValue = $"Error: {ex.Message}";
        }
    }
}
