using Recipes.Models;

namespace Recipes.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<IngredientQuantity> IngredientQueantities { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Quantity> Quantities { get; set; }
}