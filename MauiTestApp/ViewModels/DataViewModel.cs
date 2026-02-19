using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiTestApp.Models;
using MauiTestApp.Services;

namespace MauiTestApp.ViewModels;

/// <summary>
/// ViewModel for the CollectionView & Data Binding demo.
/// Demonstrates grouped data, search filtering, pull-to-refresh, and swipe-to-delete.
/// </summary>
public partial class DataViewModel : BaseViewModel
{
    private readonly SampleDataService _dataService;
    private List<SampleDataItem> _allItems = [];

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private bool _isRefreshing;

    public ObservableCollection<DataGroup> GroupedItems { get; } = [];

    public DataViewModel(SampleDataService dataService)
    {
        _dataService = dataService;
        Title = "CollectionView Demo";
        LoadData();
    }

    partial void OnSearchTextChanged(string value)
    {
        FilterItems();
    }

    private void LoadData()
    {
        _allItems = _dataService.GetSampleData();
        FilterItems();
    }

    private void FilterItems()
    {
        var filtered = string.IsNullOrWhiteSpace(SearchText)
            ? _allItems
            : _allItems.Where(i =>
                i.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                i.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                i.Category.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
              .ToList();

        var groups = filtered
            .GroupBy(i => i.Category)
            .OrderBy(g => g.Key)
            .Select(g => new DataGroup(g.Key, g.ToList()));

        GroupedItems.Clear();
        foreach (var group in groups)
        {
            GroupedItems.Add(group);
        }
    }

    [RelayCommand]
    private async Task Refresh()
    {
        IsRefreshing = true;
        // Simulate network delay
        await Task.Delay(1500);
        LoadData();
        IsRefreshing = false;
    }

    [RelayCommand]
    private void DeleteItem(SampleDataItem item)
    {
        _allItems.Remove(item);
        FilterItems();
    }
}

/// <summary>
/// Grouping class for CollectionView grouped display.
/// </summary>
public class DataGroup : List<SampleDataItem>
{
    public string CategoryName { get; }

    public DataGroup(string categoryName, List<SampleDataItem> items) : base(items)
    {
        CategoryName = categoryName;
    }
}
