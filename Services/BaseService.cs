namespace Recipes.Services;

public abstract class BaseService
{
  private protected readonly DataContext _dataContext;

  public BaseService(DataContext dataContext)
  {
    this._dataContext = dataContext;
  }
}
