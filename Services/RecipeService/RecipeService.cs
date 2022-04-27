using Recipes.Models;

namespace Recipes.Services.RecipeService;

public class RecipeService : BaseService, IRecipeService
{
  public RecipeService(DataContext dataContext) : base(dataContext)
  {
  }

  public async Task<List<Recipe>> AddNewObject(Recipe newObject)
  {
    this._dataContext.Recipes.Add(newObject);
    await this._dataContext.SaveChangesAsync();
    return new List<Recipe> { newObject };
  }

  public async Task<List<Recipe>> DeleteObject(int id)
  {
    var recipe = await this._dataContext.Recipes.FindAsync(id);
    if (recipe == null)
    {
      throw new NullReferenceException("Recipe not found.");
    }

    this._dataContext.Recipes.Remove(recipe);
    await this._dataContext.SaveChangesAsync();

    return await GetAll();
  }

  public async Task<List<Recipe>> GetAll()
  {
    var recipes = await this._dataContext.Recipes
                    .Include(r => r.Ingredients).ToListAsync();
    return recipes;
  }

  public async Task<Recipe> GetById(int id)
  {
    var recipe = await this._dataContext.Recipes
                    .Include(r => r.Ingredients)
                    .FirstOrDefaultAsync(r => r.Id == id);
    return recipe;
  }

  public async Task<Recipe> UpdateObject(Recipe updateObject)
  {
    var recipe = await this._dataContext.Recipes.FindAsync(updateObject.Id);
    if (recipe == null)
    {
      throw new NullReferenceException("Recipe not found.");
    }
    
    recipe.Name = updateObject.Name;
    recipe.Difficulty = updateObject.Difficulty;
    recipe.PeopleCount = updateObject.PeopleCount;
    recipe.Time = updateObject.Time;

    await this._dataContext.SaveChangesAsync();
    return recipe;
  }
}