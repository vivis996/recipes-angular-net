namespace Recipes.Models;

public class Quantity
{
  public int Id { get; set; }
  public int Count { get; set; }
  public KindQuantity Kind { get; set; }
}
