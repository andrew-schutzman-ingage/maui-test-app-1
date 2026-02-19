using MauiTestApp.ViewModels;

namespace MauiTestApp.Views.Controls;

public partial class ControlsPage : ContentPage
{
    public ControlsPage(ControlsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
