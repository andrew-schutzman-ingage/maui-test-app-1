# MAUI Feature Showcase

A .NET MAUI application demonstrating the breadth of features available for cross-platform development with .NET MAUI.

## Features

- **Controls Gallery** - Interactive demos of 14 MAUI controls: Button, Entry, Editor, CheckBox, Switch, Slider, Stepper, DatePicker, TimePicker, Picker, ActivityIndicator, ProgressBar, SearchBar, and more
- **Layouts Demo** - Visual demonstrations of VerticalStackLayout, HorizontalStackLayout, Grid (with column/row spanning), FlexLayout (CSS Flexbox), and AbsoluteLayout
- **CollectionView & Data** - Grouped data display with real-time search filtering, pull-to-refresh, swipe-to-delete, and empty view states
- **Graphics & Animations** - Custom IDrawable shapes (circles, gradients, star path, bezier curves), built-in animations (fade, rotate, scale, translate, composite), and Visual State Manager
- **Platform Features** - Device info, connectivity check, clipboard, share sheet, geolocation, vibration, flashlight, and Preferences key-value storage

## Architecture

- **Pattern**: MVVM (Model-View-ViewModel) using CommunityToolkit.Mvvm
- **Navigation**: .NET MAUI Shell with registered routes
- **DI**: Built-in Microsoft.Extensions.DependencyInjection
- **UI**: XAML with data binding, styles in ResourceDictionary

## Requirements

- .NET 9 SDK
- Visual Studio 2022 (17.8+) with .NET MAUI workload
- **or** VS Code with .NET MAUI extension

## Build & Run

1. Open `MauiTestApp/MauiTestApp.csproj` in Visual Studio
2. Select a target platform (Windows, Android emulator, iOS simulator, etc.)
3. Press F5 to build and run

Or from the command line (Windows/macOS only):

```bash
cd MauiTestApp
dotnet build -f net9.0-windows10.0.19041.0   # Windows
dotnet build -f net9.0-android                 # Android
dotnet build -f net9.0-ios                     # iOS
dotnet build -f net9.0-maccatalyst             # macOS
```

## Project Structure

```
MauiTestApp/
├── Models/           # Data models (FeatureCategory, FeatureDemo, SampleDataItem)
├── ViewModels/       # MVVM ViewModels with ObservableObject and RelayCommand
├── Views/            # XAML pages organized by feature category
│   ├── Controls/     # Controls gallery
│   ├── Layouts/      # Layout demonstrations
│   ├── Data/         # CollectionView demo
│   ├── Graphics/     # Shapes, animations, visual states
│   └── Platform/     # Device and platform APIs
├── Converters/       # IValueConverter implementations
├── Services/         # Data services
└── Resources/        # Styles, fonts, images
```

## Spec-Driven Development

This project was built using [GitHub Spec Kit](https://github.com/github/spec-kit). See `.specify/` for the specification, implementation plan, and task breakdown.
