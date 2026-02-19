using MauiTestApp.Models;

namespace MauiTestApp.Services;

public class SampleDataService
{
    public List<SampleDataItem> GetSampleData()
    {
        return
        [
            new() { Name = "Alpine Mountains", Description = "Snow-capped peaks reaching into the clouds", Category = "Nature", ImageUrl = "mountain" },
            new() { Name = "Ocean Sunset", Description = "Golden light reflecting off calm waters", Category = "Nature", ImageUrl = "ocean" },
            new() { Name = "Forest Trail", Description = "A winding path through ancient trees", Category = "Nature", ImageUrl = "forest" },
            new() { Name = "Desert Dunes", Description = "Rolling sand dunes under a clear sky", Category = "Nature", ImageUrl = "desert" },
            new() { Name = "Tropical Beach", Description = "White sand and turquoise waters", Category = "Nature", ImageUrl = "beach" },

            new() { Name = "Golden Gate Bridge", Description = "Iconic suspension bridge in San Francisco", Category = "Architecture", ImageUrl = "bridge" },
            new() { Name = "Eiffel Tower", Description = "Wrought-iron lattice tower in Paris", Category = "Architecture", ImageUrl = "tower" },
            new() { Name = "Modern Skyscraper", Description = "Glass and steel reaching skyward", Category = "Architecture", ImageUrl = "skyscraper" },
            new() { Name = "Ancient Temple", Description = "Stone ruins from a bygone era", Category = "Architecture", ImageUrl = "temple" },
            new() { Name = "Gothic Cathedral", Description = "Pointed arches and stained glass", Category = "Architecture", ImageUrl = "cathedral" },

            new() { Name = "Electric Car", Description = "The future of sustainable transport", Category = "Technology", ImageUrl = "car" },
            new() { Name = "Smartphone", Description = "A pocket computer connecting the world", Category = "Technology", ImageUrl = "phone" },
            new() { Name = "Robot Arm", Description = "Precision automation in manufacturing", Category = "Technology", ImageUrl = "robot" },
            new() { Name = "Solar Panel", Description = "Harnessing energy from the sun", Category = "Technology", ImageUrl = "solar" },
            new() { Name = "Drone", Description = "Aerial photography and delivery", Category = "Technology", ImageUrl = "drone" },

            new() { Name = "Pasta Carbonara", Description = "Classic Italian comfort food", Category = "Food", ImageUrl = "pasta" },
            new() { Name = "Sushi Platter", Description = "Fresh fish and seasoned rice", Category = "Food", ImageUrl = "sushi" },
            new() { Name = "Chocolate Cake", Description = "Rich and decadent dessert", Category = "Food", ImageUrl = "cake" },
            new() { Name = "Fresh Salad", Description = "Crisp greens with vinaigrette", Category = "Food", ImageUrl = "salad" },
            new() { Name = "Artisan Coffee", Description = "Carefully roasted and brewed", Category = "Food", ImageUrl = "coffee" },

            new() { Name = "Jazz Concert", Description = "Live improvisation and smooth melodies", Category = "Entertainment", ImageUrl = "jazz" },
            new() { Name = "Movie Premiere", Description = "Red carpet and silver screen magic", Category = "Entertainment", ImageUrl = "movie" },
            new() { Name = "Art Exhibition", Description = "Contemporary works on display", Category = "Entertainment", ImageUrl = "art" },
            new() { Name = "Video Game", Description = "Interactive digital entertainment", Category = "Entertainment", ImageUrl = "game" },
            new() { Name = "Book Club", Description = "Sharing stories and perspectives", Category = "Entertainment", ImageUrl = "book" },
        ];
    }

    public List<string> GetCategories()
    {
        return GetSampleData()
            .Select(i => i.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }
}
