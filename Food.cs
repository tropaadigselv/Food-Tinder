namespace FoodTinderWeb
{
    public class Food
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public List<Instruction> analyzedInstructions  { get; set; }
    }

    public class Instruction
    {
        public string Name { get; set; }
        public List<Step> Steps { get; set; }
    }

    public class Step
    {
        public int Number { get; set; }
        public string StepText { get; set; }  // maps to "step"
        public List<Ingredient> Ingredients { get; set; }
        public List<Equipment> Equipment { get; set; }
        public Length Length { get; set; }
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string Image { get; set; }
    }

    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string Image { get; set; }
    }

    public class Length
    {
        public int Number { get; set; }
        public string Unit { get; set; }
    }
    
    
    
}