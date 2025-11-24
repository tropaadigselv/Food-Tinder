using Microsoft.AspNetCore.Identity;

namespace FoodTinderWeb;

public class FoodUser : IdentityUser
{
    public required string Name {get; set;}
}