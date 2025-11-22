using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace FoodTinderWeb;

class Get
{
    public static async void Start(Params par)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-key",new StreamReader("key.txt").ReadLine());
        await ProcessCallAsync(client, par);
    }
    
    private static async Task ProcessCallAsync(HttpClient client, Params par)
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
        
        await using Stream stream = await client.GetStreamAsync(url);

        var response = await JsonSerializer.DeserializeAsync<FoodSearchResponse>(
            stream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
    }
}


public class FoodSearchResponse
{
    public List<Food> Results { get; set; } = new();
    public int Offset { get; set; }
    public int Number { get; set; }
    public int TotalResults { get; set; }
}