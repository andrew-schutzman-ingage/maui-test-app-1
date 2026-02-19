namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadWebApp();
    }

    private async void LoadWebApp()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("index.html");
            using var reader = new StreamReader(stream);
            var html = await reader.ReadToEndAsync();
            AppWebView.Source = new HtmlWebViewSource { Html = html };
        }
        catch (Exception ex)
        {
            AppWebView.Source = new HtmlWebViewSource
            {
                Html = $"<html><body><h1>Error loading app</h1><p>{ex.Message}</p></body></html>"
            };
        }
    }
}
