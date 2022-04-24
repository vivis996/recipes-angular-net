namespace Recipes.Models;

public class Recipe
{
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }
    public int PeopleCount { get; set; }
    public Time Time { get; set; }
    public IngredientQuantity[] Ingredients { get; set; }
}
