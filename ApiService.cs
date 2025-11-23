using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace FoodTinderWeb;

public class ApiService
{
    private readonly HttpClient _client;
    public ApiService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<Recipe>> ProcessCallAsync(Params par)
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
        
        await using Stream stream = await _client.GetStreamAsync(url);

        var response = await JsonSerializer.DeserializeAsync<FoodSearchResponse>(
            stream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
        return response.Results;
    }
}


public class FoodSearchResponse
{
    public List<Recipe> Results { get; set; } = new();
    public int Offset { get; set; }
    public int Number { get; set; }
    public int TotalResults { get; set; }
}