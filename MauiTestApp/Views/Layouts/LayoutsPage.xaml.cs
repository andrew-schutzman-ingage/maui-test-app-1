using MauiTestApp.ViewModels;

namespace MauiTestApp.Views.Layouts;

public partial class LayoutsPage : ContentPage
{
    public LayoutsPage(LayoutsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
