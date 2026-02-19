using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiTestApp.ViewModels;

/// <summary>
/// Base class for all ViewModels providing common observable properties.
/// Uses CommunityToolkit.Mvvm source generators for INotifyPropertyChanged.
/// </summary>
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title = string.Empty;
}
