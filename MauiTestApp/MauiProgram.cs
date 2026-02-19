using MauiTestApp.Services;

namespace MauiTestApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddMauiBlazorWebView();

        // Services
        builder.Services.AddSingleton<SampleDataService>();
        builder.Services.AddSingleton<IPlatformService, MauiPlatformService>();

        return builder.Build();
    }
}
