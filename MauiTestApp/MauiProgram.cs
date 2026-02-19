using CommunityToolkit.Maui;
using MauiTestApp.Services;
using MauiTestApp.ViewModels;
using MauiTestApp.Views;
using MauiTestApp.Views.Controls;
using MauiTestApp.Views.Data;
using MauiTestApp.Views.Graphics;
using MauiTestApp.Views.Layouts;
using MauiTestApp.Views.Platform;

namespace MauiTestApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<SampleDataService>();

        // ViewModels
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<ControlsViewModel>();
        builder.Services.AddTransient<LayoutsViewModel>();
        builder.Services.AddTransient<DataViewModel>();
        builder.Services.AddTransient<GraphicsViewModel>();
        builder.Services.AddTransient<PlatformViewModel>();

        // Pages
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ControlsPage>();
        builder.Services.AddTransient<LayoutsPage>();
        builder.Services.AddTransient<DataPage>();
        builder.Services.AddTransient<GraphicsPage>();
        builder.Services.AddTransient<PlatformPage>();

        return builder.Build();
    }
}
