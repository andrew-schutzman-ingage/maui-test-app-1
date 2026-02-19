<!-- Sync Impact Report
  Version change: 0.0.0 → 1.0.0 (initial ratification)
  Added principles: MVVM Architecture, Cross-Platform First, Feature Isolation, XAML Best Practices, Simplicity & Clarity
  Added sections: Technology Constraints, Development Workflow
  Templates requiring updates: ✅ spec-template.md (no changes needed), ✅ plan-template.md (no changes needed), ✅ tasks-template.md (no changes needed)
  Follow-up TODOs: none
-->

# MAUI Test App Constitution

## Core Principles

### I. MVVM Architecture

All features MUST follow the Model-View-ViewModel pattern. Views are defined in XAML with code-behind limited to UI-only logic. ViewModels MUST expose data via observable properties and commands. Models represent domain data and MUST NOT reference UI concerns. Data binding MUST be used to connect Views to ViewModels — no direct manipulation of UI elements from business logic.

### II. Cross-Platform First

All code MUST target Android, iOS, macOS, and Windows via .NET MAUI's cross-platform abstractions. Platform-specific code is permitted only when demonstrating platform-specific MAUI features and MUST be isolated using partial classes or the MAUI platform-specific patterns. No feature may depend on a single platform to function.

### III. Feature Isolation

Each MAUI feature demonstration MUST be self-contained in its own page or set of pages. Navigation between feature demos MUST use Shell or standard MAUI navigation. Adding or removing a feature demo MUST NOT break other demos. Shared utilities (converters, base classes) are permitted but MUST be minimal.

### IV. XAML Best Practices

UI MUST be defined in XAML, not procedural C# code, except where demonstrating programmatic UI construction as a feature. Styles and resources MUST be defined in resource dictionaries. Reusable visual elements MUST use ContentView or custom controls. Layouts MUST use the appropriate MAUI layout containers (Grid, VerticalStackLayout, HorizontalStackLayout, FlexLayout) for their use case.

### V. Simplicity & Clarity

This is a showcase/demo application. Code MUST prioritize readability and educational value over production-grade complexity. Each feature demo SHOULD include inline comments explaining the MAUI concept being demonstrated. Avoid unnecessary abstractions, dependency injection frameworks, or third-party libraries unless demonstrating MAUI integration patterns.

## Technology Constraints

- **Framework**: .NET MAUI (.NET 9)
- **Language**: C# 13 / XAML
- **IDE**: Visual Studio 2022 or VS Code with MAUI extension
- **No third-party UI libraries** unless explicitly demonstrating integration
- **NuGet packages**: MAUI Community Toolkit is permitted for extended controls and behaviors
- **Minimum targets**: Android 5.0 (API 21), iOS 15.0, macOS 12.0, Windows 10.0.17763.0

## Development Workflow

- Each feature demo is developed on its own feature branch
- Feature branches merge to `main` after verification
- Commits SHOULD be granular — one logical change per commit
- XAML and code-behind files MUST be committed together
- The app MUST build without warnings before merging

## Governance

This constitution governs all development on the MAUI Test App project. Amendments require updating this document with a version bump and documenting the rationale. All code contributions MUST comply with these principles. Refer to `CLAUDE.md` for runtime development guidance.

**Version**: 1.0.0 | **Ratified**: 2026-02-18 | **Last Amended**: 2026-02-18
