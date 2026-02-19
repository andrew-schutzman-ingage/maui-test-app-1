using MauiTestApp.Views.Controls;
using MauiTestApp.Views.Data;
using MauiTestApp.Views.Graphics;
using MauiTestApp.Views.Layouts;
using MauiTestApp.Views.Platform;

namespace MauiTestApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute(nameof(ControlsPage), typeof(ControlsPage));
        Routing.RegisterRoute(nameof(LayoutsPage), typeof(LayoutsPage));
        Routing.RegisterRoute(nameof(DataPage), typeof(DataPage));
        Routing.RegisterRoute(nameof(GraphicsPage), typeof(GraphicsPage));
        Routing.RegisterRoute(nameof(PlatformPage), typeof(PlatformPage));
    }
}
