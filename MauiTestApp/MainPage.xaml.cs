namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override bool OnBackButtonPressed()
    {
        _ = HandleBackButtonAsync();
        return true;
    }

    private async Task HandleBackButtonAsync()
    {
        try
        {
            var result = await AppWebView.EvaluateJavaScriptAsync(
                "(function(){ var h = window.location.hash; if (h && h !== '#/' && h !== '#') { window.history.back(); return 1; } return 0; })()");

            if (result?.Trim('"') == "0")
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                    Application.Current?.Quit());
            }
        }
        catch
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
                Application.Current?.Quit());
        }
    }
}
