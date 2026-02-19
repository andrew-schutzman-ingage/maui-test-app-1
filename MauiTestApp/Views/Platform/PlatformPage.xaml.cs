using MauiTestApp.ViewModels;

namespace MauiTestApp.Views.Platform;

public partial class PlatformPage : ContentPage
{
    public PlatformPage(PlatformViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
