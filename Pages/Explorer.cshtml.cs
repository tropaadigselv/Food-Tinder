using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace FoodTinderWeb.Pages;

public class Explorer : PageModel
{
    private readonly ApiService _apiService;
    public FoodViewModel recipes { get; set; }
    private readonly ILogger<Explorer> _logger;

    public Explorer(ApiService apiService, ILogger<Explorer> logger)
    {
        _apiService = apiService;
        _logger = logger;   
    }
    
    public async Task<ActionResult> OnGet()
    {
        //do so it only calls when the list is empty
        recipes = await _apiService.ProcessCallAsync(new Params(){Exclude = new string[]{"shrimp"},Diet = null});
        _logger.LogInformation("explorer {explorer} recipes", recipes.recipes.Count);
        return Page();
    }
}