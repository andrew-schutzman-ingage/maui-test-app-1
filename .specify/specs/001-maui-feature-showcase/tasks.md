# Tasks: MAUI Feature Showcase

**Input**: Design documents from `.specify/specs/001-maui-feature-showcase/`
**Prerequisites**: plan.md (required), spec.md (required)

## Phase 1: Setup

**Purpose**: Create the .NET MAUI project and foundational structure

- [ ] T001 Create .NET MAUI project `MauiTestApp` targeting .NET 9 with default template
- [ ] T002 Add NuGet packages: CommunityToolkit.Mvvm, CommunityToolkit.Maui
- [ ] T003 [P] Create directory structure: Models/, ViewModels/, Views/Controls/, Views/Layouts/, Views/Data/, Views/Graphics/, Views/Platform/, Converters/, Services/
- [ ] T004 [P] Configure App.xaml with global styles (colors, fonts, button styles, label styles, frame styles)

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core models, base ViewModel, Shell navigation, and home page — everything else depends on these

- [ ] T005 Create BaseViewModel.cs with ObservableObject, IsBusy, Title properties
- [ ] T006 [P] Create FeatureCategory.cs model (Name, Icon, Description, list of FeatureDemo)
- [ ] T007 [P] Create FeatureDemo.cs model (Name, Description, Icon, TargetRoute)
- [ ] T008 [P] Create SampleDataItem.cs model (Name, Description, Category, ImageUrl)
- [ ] T009 Configure AppShell.xaml with Shell routes for all demo pages (HomePage, ControlsPage, LayoutsPage, DataPage, GraphicsPage, PlatformPage)
- [ ] T010 Register routes and ViewModels in MauiProgram.cs (DI registration)
- [ ] T011 Create HomeViewModel.cs with categorized list of feature demos
- [ ] T012 Create HomePage.xaml with CollectionView grouped by category, each item navigating to its demo page

**Checkpoint**: App launches, shows home page with categorized feature list, tapping an item navigates (to empty pages)

---

## Phase 3: User Story 2 - Controls Gallery (Priority: P1)

**Goal**: Interactive gallery of MAUI's built-in controls with data binding

**Independent Test**: Navigate to Controls from home, interact with each control, verify bound state updates

### Implementation

- [ ] T013 Create ControlsViewModel.cs with observable properties: CounterValue, EntryText, EditorText, IsChecked, IsSwitched, SliderValue, StepperValue, SelectedDate, SelectedTime, SelectedPickerItem, SearchText, ProgressValue, IsLoading; and commands: IncrementCommand, ToggleLoadingCommand
- [ ] T014 Create Views/Controls/ControlsPage.xaml with sections for each control:
  - Button with tap counter
  - Label bound to EntryText
  - Entry with two-way binding
  - Editor with character count
  - CheckBox with bound state display
  - Switch with bound state display
  - Slider with value display
  - Stepper with value display
  - DatePicker with selected date display
  - TimePicker with selected time display
  - Picker with list of items
  - ActivityIndicator toggled by button
  - ProgressBar bound to slider
  - SearchBar with search text display

**Checkpoint**: Controls page fully interactive, all bindings working

---

## Phase 4: User Story 3 - Layouts Demo (Priority: P2)

**Goal**: Visual demonstrations of MAUI layout containers

**Independent Test**: Navigate to Layouts from home, verify each layout arranges children correctly with descriptions

### Implementation

- [ ] T015 Create LayoutsViewModel.cs (Title property, minimal state)
- [ ] T016 Create Views/Layouts/LayoutsPage.xaml with labeled sections:
  - VerticalStackLayout with numbered colored boxes stacked vertically
  - HorizontalStackLayout with numbered colored boxes stacked horizontally
  - Grid with 3x3 grid of labeled cells showing Row/Column positions
  - FlexLayout with wrapping colored items demonstrating Wrap, JustifyContent, AlignItems
  - AbsoluteLayout with overlapping positioned elements

**Checkpoint**: Layouts page renders all 5 layout types with clear visual arrangement

---

## Phase 5: User Story 4 - CollectionView & Data Binding (Priority: P2)

**Goal**: Rich data list with grouping, search, refresh, swipe actions, and empty state

**Independent Test**: Navigate to Data from home, verify list loads, search filters, pull-to-refresh works, swipe actions appear

### Implementation

- [ ] T017 Create Services/SampleDataService.cs generating 25+ SampleDataItems across 4-5 categories
- [ ] T018 Create DataViewModel.cs with: ObservableCollection of grouped items, SearchText property with filtering logic, RefreshCommand with simulated delay, DeleteCommand for swipe-to-delete, IsRefreshing property, filtered items computed property
- [ ] T019 Create Views/Data/DataPage.xaml with:
  - SearchBar bound to SearchText
  - RefreshView wrapping CollectionView with pull-to-refresh
  - CollectionView with GroupHeaderTemplate showing category name
  - ItemTemplate with item name, description, and category badge
  - SwipeView with delete swipe action
  - EmptyView showing "No items found" when filtered list is empty

**Checkpoint**: Data page shows grouped list, search filters in real-time, pull-to-refresh animates, swipe-to-delete works, empty view shows when no matches

---

## Phase 6: User Story 5 - Graphics & Animations (Priority: P3)

**Goal**: MAUI graphics drawing and animation demonstrations

**Independent Test**: Navigate to Graphics from home, verify shapes render, tap buttons to trigger animations

### Implementation

- [ ] T020 Create GraphicsViewModel.cs with commands: FadeCommand, RotateCommand, ScaleCommand, TranslateCommand, CompositeCommand
- [ ] T021 Create a custom GraphicsDrawable implementing IDrawable that draws: filled circle, stroked rectangle, gradient-filled rounded rectangle, bezier path, and a simple star shape
- [ ] T022 Create Views/Graphics/GraphicsPage.xaml with:
  - GraphicsView using the custom drawable
  - Section with a target BoxView/Frame and buttons for each animation type (Fade, Rotate, Scale, Translate, Composite)
  - Visual state demo showing a button that changes appearance on Normal/PointerOver/Pressed states

**Checkpoint**: Graphics page shows drawn shapes and all animations trigger correctly

---

## Phase 7: User Story 6 - Platform Features (Priority: P3)

**Goal**: Demonstrate MAUI's cross-platform API abstractions

**Independent Test**: Navigate to Platform from home, verify device info shows, tap buttons to invoke platform APIs

### Implementation

- [ ] T023 Create PlatformViewModel.cs with:
  - Properties: DeviceManufacturer, DeviceModel, OSVersion, DeviceIdiom, ConnectivityStatus, ClipboardText, LocationText, PreferenceValue
  - Commands: CheckConnectivityCommand, CopyToClipboardCommand, PasteFromClipboardCommand, ShareTextCommand, GetLocationCommand, VibrateCommand, ToggleFlashlightCommand, SavePreferenceCommand, ReadPreferenceCommand
  - Try/catch with "Not supported" messages for unavailable features
- [ ] T024 Create Views/Platform/PlatformPage.xaml with:
  - Device Info section showing manufacturer, model, OS, idiom in a styled card
  - Connectivity section with check button and status display
  - Clipboard section with copy/paste buttons and text display
  - Share section with share button
  - Geolocation section with get location button and coordinates display
  - Haptics section with vibrate button
  - Flashlight section with toggle button
  - Preferences section with save/read buttons and value display

**Checkpoint**: Platform page displays device info, each platform API button works or shows "Not supported" gracefully

---

## Phase 8: Polish & Cross-Cutting Concerns

**Purpose**: Final cleanup and consistency

- [ ] T025 [P] Add descriptive header/comment to each demo page explaining the MAUI concept being showcased
- [ ] T026 [P] Add app icon and splash screen resources
- [ ] T027 [P] Ensure consistent styling across all pages (spacing, fonts, colors)
- [ ] T028 Update README.md with project description, build instructions, and feature list
- [ ] T029 Verify app builds without warnings

---

## Dependencies & Execution Order

### Phase Dependencies

- **Phase 1 (Setup)**: No dependencies — start immediately
- **Phase 2 (Foundational)**: Depends on Phase 1 — BLOCKS all user stories
- **Phase 3-7 (User Stories)**: All depend on Phase 2 completion. Can proceed sequentially in priority order: P1 → P2 → P3
- **Phase 8 (Polish)**: Depends on all user story phases

### Within Each User Story

- ViewModel before View (ViewModel defines the binding contract)
- Services before ViewModels that consume them (T017 before T018)
- Core implementation before polish

### Parallel Opportunities

- T003, T004 can run in parallel (different files)
- T006, T007, T008 can run in parallel (independent model files)
- Phase 3-7 user stories are independent and could theoretically run in parallel
- T025, T026, T027 can run in parallel (different concerns)
