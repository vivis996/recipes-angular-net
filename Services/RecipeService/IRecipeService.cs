using Recipes.Models;

namespace Recipes.Services.RecipeService;

public interface IRecipeService
{
  Task<List<Recipe>> GetAll();
  Task<Recipe> GetById(int id);
  Task<List<Recipe>> AddNewObject(Recipe newObject);
  Task<Recipe> UpdateObject(Recipe updateObject);
  Task<List<Recipe>> DeleteObject(int id);
}
