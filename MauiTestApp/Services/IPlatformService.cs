namespace MauiTestApp.Services;

public interface IPlatformService
{
    string DeviceManufacturer { get; }
    string DeviceModel { get; }
    string OsVersion { get; }
    string DeviceIdiom { get; }
    string DevicePlatform { get; }

    string CheckConnectivity();
    Task CopyToClipboard(string text);
    Task<string> PasteFromClipboard();
    Task ShareText(string text, string title);
    Task<string> GetLocation();
    void Vibrate(int milliseconds);
    Task<string> ToggleFlashlight();
    void SavePreference(string key, string value);
    string ReadPreference(string key);
}
