using Recipes.Models;

namespace Recipes.Services.RecipeService;

public interface IRecipeService
{
  Task<ServiceResponse<List<Recipe>>> GetAll();
  Task<ServiceResponse<Recipe>> GetById(int id);
  Task<ServiceResponse<List<Recipe>>> AddNewObject(Recipe newObject);
  Task<ServiceResponse<Recipe>> UpdateObject(Recipe updateObject);
  Task<ServiceResponse<List<Recipe>>> DeleteObject(int id);
}
