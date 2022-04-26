namespace Recipes.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Difficulty Difficulty { get; set; }
    public int PeopleCount { get; set; }
    public TimeSpan Time { get; set; }
    public List<IngredientQuantity> Ingredients { get; set; }
}
