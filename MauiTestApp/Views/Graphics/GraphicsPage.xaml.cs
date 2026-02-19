using MauiTestApp.ViewModels;

namespace MauiTestApp.Views.Graphics;

/// <summary>
/// Code-behind for GraphicsPage. Animation methods are defined here because
/// MAUI animations are extension methods on View that require a direct reference
/// to the visual element — they cannot be triggered from a ViewModel alone.
/// </summary>
public partial class GraphicsPage : ContentPage
{
    private readonly GraphicsViewModel _viewModel;

    public GraphicsPage(GraphicsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    private async void OnFadeClicked(object? sender, EventArgs e)
    {
        _viewModel.AnimationStatus = "Fade animation running...";
        await AnimationTarget.FadeTo(0.2, 400, Easing.CubicInOut);
        await AnimationTarget.FadeTo(1.0, 400, Easing.CubicInOut);
        _viewModel.AnimationStatus = "Fade complete!";
    }

    private async void OnRotateClicked(object? sender, EventArgs e)
    {
        _viewModel.AnimationStatus = "Rotate animation running...";
        await AnimationTarget.RotateTo(360, 600, Easing.SpringOut);
        AnimationTarget.Rotation = 0;
        _viewModel.AnimationStatus = "Rotate complete!";
    }

    private async void OnScaleClicked(object? sender, EventArgs e)
    {
        _viewModel.AnimationStatus = "Scale animation running...";
        await AnimationTarget.ScaleTo(1.5, 300, Easing.CubicOut);
        await AnimationTarget.ScaleTo(1.0, 300, Easing.BounceOut);
        _viewModel.AnimationStatus = "Scale complete!";
    }

    private async void OnTranslateClicked(object? sender, EventArgs e)
    {
        _viewModel.AnimationStatus = "Translate animation running...";
        await AnimationTarget.TranslateTo(80, 0, 300, Easing.CubicInOut);
        await AnimationTarget.TranslateTo(-80, 0, 300, Easing.CubicInOut);
        await AnimationTarget.TranslateTo(0, 0, 300, Easing.CubicInOut);
        _viewModel.AnimationStatus = "Translate complete!";
    }

    private async void OnCompositeClicked(object? sender, EventArgs e)
    {
        _viewModel.AnimationStatus = "Composite animation running...";

        // Run multiple animations simultaneously
        await Task.WhenAll(
            AnimationTarget.RotateTo(360, 800, Easing.CubicInOut),
            AnimationTarget.ScaleTo(1.3, 400, Easing.CubicOut),
            AnimationTarget.FadeTo(0.5, 400, Easing.CubicInOut)
        );

        await Task.WhenAll(
            AnimationTarget.ScaleTo(1.0, 400, Easing.BounceOut),
            AnimationTarget.FadeTo(1.0, 400, Easing.CubicInOut)
        );

        AnimationTarget.Rotation = 0;
        _viewModel.AnimationStatus = "Composite complete!";
    }

    private void OnResetClicked(object? sender, EventArgs e)
    {
        AnimationTarget.CancelAnimations();
        AnimationTarget.Rotation = 0;
        AnimationTarget.Scale = 1;
        AnimationTarget.Opacity = 1;
        AnimationTarget.TranslationX = 0;
        AnimationTarget.TranslationY = 0;
        _viewModel.AnimationStatus = "Reset to original state";
    }
}
