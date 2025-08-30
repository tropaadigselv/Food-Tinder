namespace Food;

public class User
{
    public int PersonID { get; set; }
    public string name {get; set;}
    public override string ToString()
    {
        return name;
    }
}