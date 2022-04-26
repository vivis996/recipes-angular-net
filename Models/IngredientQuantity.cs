namespace Recipes.Models;

public class IngredientQuantity
{
  public int Id { get; set; }
  public int RecipeId { get; set; }
  public int IngredientId { get; set; }
  public int QuantityId { get; set; }
}
