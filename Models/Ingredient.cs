namespace Recipes.Models;

public class Ingredient
{
  public int Id { get; set; }
  public string Name { get; set; }
  public KindIngredient Kind { get; set; }
}
