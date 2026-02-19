using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models;

namespace MauiTestApp.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<FeatureCategory> Categories { get; } = [];

    public HomeViewModel()
    {
        Title = "MAUI Feature Showcase";
        LoadCategories();
    }

    private void LoadCategories()
    {
        Categories.Add(new FeatureCategory
        {
            Name = "Controls",
            Icon = "🎛️",
            Description = "Interactive UI controls",
            Demos =
            [
                new FeatureDemo
                {
                    Name = "Controls Gallery",
                    Description = "Buttons, entries, sliders, pickers, and more",
                    Icon = "🔘",
                    TargetRoute = "ControlsPage"
                }
            ]
        });

        Categories.Add(new FeatureCategory
        {
            Name = "Layouts",
            Icon = "📐",
            Description = "Layout containers and arrangement",
            Demos =
            [
                new FeatureDemo
                {
                    Name = "Layouts Demo",
                    Description = "Grid, Stack, Flex, and Absolute layouts",
                    Icon = "📏",
                    TargetRoute = "LayoutsPage"
                }
            ]
        });

        Categories.Add(new FeatureCategory
        {
            Name = "Data",
            Icon = "📊",
            Description = "Data display and binding",
            Demos =
            [
                new FeatureDemo
                {
                    Name = "CollectionView",
                    Description = "Grouping, search, refresh, and swipe actions",
                    Icon = "📋",
                    TargetRoute = "DataPage"
                }
            ]
        });

        Categories.Add(new FeatureCategory
        {
            Name = "Graphics",
            Icon = "🎨",
            Description = "Drawing and animations",
            Demos =
            [
                new FeatureDemo
                {
                    Name = "Graphics & Animations",
                    Description = "Shapes, paths, gradients, and animations",
                    Icon = "✨",
                    TargetRoute = "GraphicsPage"
                }
            ]
        });

        Categories.Add(new FeatureCategory
        {
            Name = "Platform",
            Icon = "📱",
            Description = "Device and platform APIs",
            Demos =
            [
                new FeatureDemo
                {
                    Name = "Platform Features",
                    Description = "Device info, connectivity, clipboard, share, and more",
                    Icon = "⚙️",
                    TargetRoute = "PlatformPage"
                }
            ]
        });
    }

    [RelayCommand]
    private async Task NavigateToDemo(FeatureDemo demo)
    {
        if (demo?.TargetRoute is not null)
        {
            await Shell.Current.GoToAsync(demo.TargetRoute);
        }
    }
}
