using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiTestApp.ViewModels;

/// <summary>
/// ViewModel for the Graphics & Animations demo.
/// Provides commands to trigger various animation types on a target view element.
/// </summary>
public partial class GraphicsViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _animationStatus = "Tap a button to start an animation";

    public GraphicsViewModel()
    {
        Title = "Graphics & Animations";
    }
}
