using Android.Webkit;
using Microsoft.Maui.ApplicationModel;

namespace MauiTestApp;

public class AppWebChromeClient : WebChromeClient
{
    public override async void OnPermissionRequest(PermissionRequest? request)
    {
        if (request?.GetResources() is not { Length: > 0 } resources)
        {
            request?.Deny();
            return;
        }

        bool needsCamera = resources.Any(r => r == PermissionRequest.ResourceVideoCapture);

        if (!needsCamera)
        {
            request.Grant(resources);
            return;
        }

        try
        {
            var status = await Permissions.RequestAsync<Permissions.Camera>();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (status == PermissionStatus.Granted)
                    request.Grant(resources);
                else
                    request.Deny();
            });
        }
        catch
        {
            MainThread.BeginInvokeOnMainThread(() => request.Deny());
        }
    }

    public override async void OnGeolocationPermissionsShowPrompt(string? origin, GeolocationPermissions.ICallback? callback)
    {
        if (callback == null) return;

        try
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            MainThread.BeginInvokeOnMainThread(() =>
                callback.Invoke(origin, status == PermissionStatus.Granted, false));
        }
        catch
        {
            MainThread.BeginInvokeOnMainThread(() =>
                callback.Invoke(origin, false, false));
        }
    }
}
