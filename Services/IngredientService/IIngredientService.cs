using Recipes.Models;

namespace Recipes.Services.IngredientService;

public interface IIngredientService
{
  Task<ServiceResponse<List<Ingredient>>> GetAll();
  Task<ServiceResponse<Ingredient>> GetById(int id);
  Task<ServiceResponse<List<Ingredient>>> AddNewObject(Ingredient newObject);
  Task<ServiceResponse<Ingredient>> UpdateObject(Ingredient updateObject);
  Task<ServiceResponse<List<Ingredient>>> DeleteObject(int id);
}
