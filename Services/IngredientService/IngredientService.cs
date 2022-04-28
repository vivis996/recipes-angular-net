using Recipes.Models;

namespace Recipes.Services.IngredientService;

public class IngredientService : BaseService, IIngredientService
{
  public IngredientService(DataContext dataContext) : base(dataContext)
  { }

  public async Task<ServiceResponse<List<Ingredient>>> AddNewObject(Ingredient newObject)
  {
    var serviceResponse = new ServiceResponse<List<Ingredient>>();
    try
    {
      this._dataContext.Ingredients.Add(newObject);
      await this._dataContext.SaveChangesAsync();
      serviceResponse.Data = new List<Ingredient> { newObject };
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
  }

  public async Task<ServiceResponse<List<Ingredient>>> DeleteObject(int id)
  {
    var serviceResponse = new ServiceResponse<List<Ingredient>>();
    try
    {
      var @object = await this._dataContext.Recipes.FindAsync(id);
      if (@object == null)
      {
        throw new NullReferenceException("Ingredient not found.");
      }

      this._dataContext.Recipes.Remove(@object);
      await this._dataContext.SaveChangesAsync();
      serviceResponse.Data = await this._dataContext.Ingredients.ToListAsync();
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
  }

  public async Task<ServiceResponse<List<Ingredient>>> GetAll()
  {
    var serviceResponse = new ServiceResponse<List<Ingredient>>();
    try
    {
      serviceResponse.Data = await this._dataContext.Ingredients.ToListAsync();
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
  }

  public async Task<ServiceResponse<Ingredient>> GetById(int id)
  {
    var serviceResponse = new ServiceResponse<Ingredient>();
    try
    {
      var @object = await this._dataContext.Ingredients
                      .FirstOrDefaultAsync(r => r.Id == id);
      if (@object == null)
      {
        throw new NullReferenceException("Ingredient not found.");
      }
      
      serviceResponse.Data = @object;
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
  }

  public async Task<ServiceResponse<Ingredient>> UpdateObject(Ingredient updateObject)
  {
    var serviceResponse = new ServiceResponse<Ingredient>();
    try
    {
      var @object = await this._dataContext.Ingredients.FindAsync(updateObject.Id);
      if (@object == null)
      {
        throw new NullReferenceException("Ingredient not found.");
      }
      
      @object.Name = updateObject.Name;
      @object.Kind = updateObject.Kind;

      await this._dataContext.SaveChangesAsync();
      
      serviceResponse.Data = @object;
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
  }
}
