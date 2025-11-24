using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace FoodTinderWeb;

public class ApiService
{
    private readonly HttpClient _client;
    private readonly ILogger<ApiService> _logger;
    public ApiService(HttpClient client, ILogger<ApiService> logger)
    {
        _client = client;
        _logger = logger;
    }
    
    public async Task<FoodViewModel> ProcessCallAsync(Params par)
    {

        var baseurl = "https://api.spoonacular.com/recipes/complexSearch?";

        var queryPrams = new Dictionary<string, string>()
        {
            ["number"] = "2",
            ["excludeIngredients"] = "",
            ["diet"] = "",
            ["type"] = "main course",
            ["instructionsRequired"] = "true",
            ["addRecipeInformation"] = "true",
            ["addRecipeInstructions"] = "true",
            ["offset"] = "0"
        };

        string test = String.Join(",", par.Exclude);

        queryPrams["excludeIngredients"] = test;

        queryPrams["diet"] = par.Diet;
        
        if (queryPrams["excludeIngredients"] == "") queryPrams.Remove("excludeIngredients");
        if (queryPrams["diet"] == "") queryPrams.Remove("diet");
        
        var url = QueryHelpers.AddQueryString(baseurl, queryPrams);
        
        // var json = await client.GetStringAsync(url);
        //
        // MessageBox.Show(json);
        

        var response = await _client.GetAsync(url);
        //_logger.LogInformation("got response {response}", response.Content.ReadAsStringAsync().Result);
        
        var recipeIngredients = new Dictionary<string, List<string>>();


        
        var content = await response.Content.ReadFromJsonAsync<FoodSearchResponse>();
        _logger.LogInformation("got contetnt {c}", content!.Results.Count);
        foreach (var recipe in content!.Results)
        {
            var ingredientNames = recipe.analyzedInstructions
                .SelectMany(i => i.Steps)
                .SelectMany(s => s.Ingredients)
                .Select(i => i.Name)
                .Distinct()
                .ToList();

            recipeIngredients.Add(recipe.Title, ingredientNames!);
        }
        
        return new FoodViewModel(){recipes = content.Results,ingredients = recipeIngredients};
    }
}

public class FoodViewModel
{
    public List<Recipe> recipes { get; set; }
    public Dictionary<string, List<string>> ingredients { get; set; }
    
    
}

public class FoodSearchResponse
{
    public List<Recipe> Results { get; set; } = new();
    public int Offset { get; set; }
    public int Number { get; set; }
    public int TotalResults { get; set; }
}