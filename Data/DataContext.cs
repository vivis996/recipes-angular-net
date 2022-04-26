using Recipes.Models;

namespace Recipes.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  public DbSet<Recipe> Recipes { get; set; }
  public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
  public DbSet<Ingredient> Ingredients { get; set; }
  public DbSet<Quantity> Quantities { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<IngredientQuantity>()
        .HasOne<Ingredient>(iq => iq.Ingredient)
        .WithMany(i => i.IngredientQuantities)
        .HasForeignKey(iq => iq.IngredientId);

    modelBuilder.Entity<IngredientQuantity>()
        .HasIndex(i => new { i.RecipeId, i.IngredientId, i.QuantityId })
        .IsUnique(true);
  }
}