using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace Food;

class Get
{
    async void Start()
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-key",new StreamReader("key.txt").ReadLine());
        await ProcessCallAsync(client);
    }
    
    private static async Task ProcessCallAsync(HttpClient client)
    {

        var baseurl = "https://api.spoonacular.com/recipes/complexSearch?";

        var queryPrams = new Dictionary<string, string>()
        {
            ["number"] = "2",
            ["excludeIngredients"] = "onions,tomatoes",
            ["offset"] = "0"
        };
    
        var url = QueryHelpers.AddQueryString(baseurl, queryPrams);
    
        await using Stream stream = await client.GetStreamAsync(url);

        var response = await JsonSerializer.DeserializeAsync<FoodSearchResponse>(
            stream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );

        Console.WriteLine(response.Results.Count);
    
        foreach (var food in response?.Results ?? Enumerable.Empty<Food.CLI.Food>())
        {
            Console.WriteLine(food.Title);
        }
    }
}


public class FoodSearchResponse
{
    public List<Food.CLI.Food> Results { get; set; } = new();
    public int Offset { get; set; }
    public int Number { get; set; }
    public int TotalResults { get; set; }
}