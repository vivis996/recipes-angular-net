using System.ComponentModel.DataAnnotations;

namespace Recipes.Models;

public class IngredientQuantity
{
  public int Id { get; set; }
  [Required]
  public int RecipeId { get; set; }
  public int IngredientId { get; set; }
  public Ingredient Ingredient { get; set; }
  public int QuantityId { get; set; }
  public Quantity Quantity { get; set; }
}
