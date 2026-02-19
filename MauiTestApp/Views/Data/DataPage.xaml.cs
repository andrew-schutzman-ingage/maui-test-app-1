using MauiTestApp.ViewModels;

namespace MauiTestApp.Views.Data;

public partial class DataPage : ContentPage
{
    public DataPage(DataViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
