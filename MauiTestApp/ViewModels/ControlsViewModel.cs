using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiTestApp.ViewModels;

/// <summary>
/// ViewModel for the Controls Gallery page.
/// Demonstrates data binding with a variety of MAUI input controls.
/// </summary>
public partial class ControlsViewModel : BaseViewModel
{
    [ObservableProperty]
    private int _counterValue;

    [ObservableProperty]
    private string _entryText = string.Empty;

    [ObservableProperty]
    private string _editorText = string.Empty;

    [ObservableProperty]
    private bool _isChecked;

    [ObservableProperty]
    private bool _isSwitched;

    [ObservableProperty]
    private double _sliderValue = 50;

    [ObservableProperty]
    private int _stepperValue = 5;

    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Today;

    [ObservableProperty]
    private TimeSpan _selectedTime = DateTime.Now.TimeOfDay;

    [ObservableProperty]
    private string _selectedPickerItem = "Option 1";

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private double _progressValue = 0.5;

    [ObservableProperty]
    private bool _isLoading;

    public List<string> PickerItems { get; } = ["Option 1", "Option 2", "Option 3", "Option 4", "Option 5"];

    public ControlsViewModel()
    {
        Title = "Controls Gallery";
    }

    // Character count derived from EditorText
    public int EditorCharacterCount => EditorText?.Length ?? 0;

    partial void OnEditorTextChanged(string value)
    {
        OnPropertyChanged(nameof(EditorCharacterCount));
    }

    [RelayCommand]
    private void IncrementCounter()
    {
        CounterValue++;
    }

    [RelayCommand]
    private void ToggleLoading()
    {
        IsLoading = !IsLoading;
    }
}
