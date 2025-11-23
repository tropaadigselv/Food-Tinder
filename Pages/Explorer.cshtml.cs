using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace FoodTinderWeb.Pages;

public class Explorer : PageModel
{
    private readonly ApiService _apiService;
    public List<Recipe> recipes { get; set; }

    public Explorer(ApiService apiService)
    {
        _apiService = apiService;
    }
    
    public async Task<ActionResult> OnGet()
    {
        //do so it only calls when the list is empty
        recipes = await _apiService.ProcessCallAsync(new Params(){Exclude = new string[]{"shrimp"},Diet = null});

        return Page();
    }
}