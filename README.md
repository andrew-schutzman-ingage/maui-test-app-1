# MAUI Feature Showcase (WebView + Vue.js)

A .NET MAUI application demonstrating a hybrid architecture using the native MAUI `WebView` control with a Vue.js single-page application for the UI layer.

## Architecture

This app uses a **hybrid WebView approach**:
- **Host**: .NET MAUI native app with a full-screen `WebView` control
- **UI**: Vue.js 3 SPA with Vue Router, loaded from local resources
- **Navigation**: Hash-based client-side routing handled by Vue Router
- **Styling**: CSS with dark/light theme support via `prefers-color-scheme`

## Features

- **Controls Gallery** — Interactive demos of Button, Entry, Editor, CheckBox, Switch, Slider, Stepper, DatePicker, TimePicker, Picker, ActivityIndicator, ProgressBar, and SearchBar
- **Layouts Demo** — Visual demonstrations of Vertical Stack, Horizontal Stack, Grid (with spanning), Flex Layout, and Absolute Layout
- **CollectionView & Data** — Grouped data display with real-time search filtering, refresh simulation, and delete actions
- **Graphics & Animations** — Canvas-drawn shapes (circle, rectangle, triangle), gradients, star path, bezier curves, CSS animations (fade, rotate, scale, translate, composite), and visual state management
- **Platform Features** — Device info, connectivity status, clipboard, Web Share API, geolocation, localStorage preferences, and vibration API

## Requirements

- .NET 9 SDK
- Visual Studio 2022 (17.8+) with .NET MAUI workload
- **or** VS Code with .NET MAUI extension

## Build & Run

1. Open `MauiTestApp/MauiTestApp.csproj` in Visual Studio
2. Select a target platform (Windows, Android emulator, iOS simulator, etc.)
3. Press F5 to build and run

Or from the command line:

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
├── App.xaml / App.xaml.cs        # Application entry point
├── AppShell.xaml / .cs           # Shell with single MainPage route
├── MainPage.xaml / .cs           # WebView host page (loads Vue.js SPA)
├── MauiProgram.cs                # Minimal DI configuration
├── Resources/
│   ├── Raw/
│   │   └── index.html            # Vue.js SPA (all components inline)
│   ├── Images/                   # App icons
│   ├── Splash/                   # Splash screen
│   ├── Styles/                   # MAUI styles
│   └── Fonts/                    # App fonts
└── Platforms/
    └── Windows/                  # Windows platform files
```

## How It Works

1. The MAUI app loads `MainPage`, which contains a full-screen `WebView`
2. On initialization, `MainPage.xaml.cs` reads `index.html` from app package resources
3. The HTML content (containing the Vue.js app) is set as the WebView's `HtmlWebViewSource`
4. Vue Router handles all navigation within the WebView using hash-based routing
5. All UI rendering, state management, and interactions are handled by Vue.js
