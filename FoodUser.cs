using Microsoft.AspNetCore.Identity;

namespace FoodTinderWeb;

public class FoodUser : IdentityUser
{
    public required string Name {get; set;}
    public override string ToString()
    {
        return Name;
    }
}