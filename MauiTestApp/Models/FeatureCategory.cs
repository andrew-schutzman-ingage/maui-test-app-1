namespace MauiTestApp.Models;

public class FeatureCategory
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<FeatureDemo> Demos { get; set; } = [];
}
