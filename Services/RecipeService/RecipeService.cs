using Recipes.Models;

namespace Recipes.Services.RecipeService;

public class RecipeService : BaseService, IRecipeService
{
  public RecipeService(DataContext dataContext) : base(dataContext)
  { }

  public async Task<ServiceResponse<List<Recipe>>> AddNewObject(Recipe newObject)
  {
    var serviceResponse = new ServiceResponse<List<Recipe>>();
    try
    {
      this._dataContext.Recipes.Add(newObject);
      await this._dataContext.SaveChangesAsync();
      serviceResponse.Data = new List<Recipe> { newObject };
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }
    return serviceResponse;
  }

  public async Task<ServiceResponse<List<Recipe>>> DeleteObject(int id)
  {
    var serviceResponse = new ServiceResponse<List<Recipe>>();
    try
    {
      var @object = await this._dataContext.Recipes.FindAsync(id);
      if (@object == null)
      {
        throw new NullReferenceException("Recipe not found.");
      }

      this._dataContext.Recipes.Remove(@object);
      await this._dataContext.SaveChangesAsync();
      serviceResponse.Data = await this._dataContext.Recipes
                                .Include(r => r.Ingredients).ToListAsync();
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
  }

  public async Task<ServiceResponse<List<Recipe>>> GetAll()
  {
    var serviceResponse = new ServiceResponse<List<Recipe>>();
    try
    {
      serviceResponse.Data = await this._dataContext.Recipes
                                .Include(r => r.Ingredients).ToListAsync();
    }
    catch (System.Exception ex)
    {
      serviceResponse.Success = false;
      serviceResponse.Message = ex.Message;
    }

    return serviceResponse;
  }

  public async Task<ServiceResponse<Recipe>> GetById(int id)
  {
    var serviceResponse = new ServiceResponse<Recipe>();
    try
    {
      var @object = await this._dataContext.Recipes
                      .Include(r => r.Ingredients)
                      .FirstOrDefaultAsync(r => r.Id == id);
      if (@object == null)
      {
        throw new NullReferenceException("Recipe not found.");
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

  public async Task<ServiceResponse<Recipe>> UpdateObject(Recipe updateObject)
  {
    var serviceResponse = new ServiceResponse<Recipe>();
    try
    {
      var @object = await this._dataContext.Recipes.FindAsync(updateObject.Id);
      if (@object == null)
      {
        throw new NullReferenceException("Recipe not found.");
      }
      
      @object.Name = updateObject.Name;
      @object.Difficulty = updateObject.Difficulty;
      @object.PeopleCount = updateObject.PeopleCount;
      @object.Time = updateObject.Time;

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