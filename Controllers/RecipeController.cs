using Microsoft.AspNetCore.Mvc;
using Recipes.Models;

namespace Recipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
  private readonly string[] Recipes = new string[]
  {
    "Frijoles", "Lentejas", "Quesadillas", "Sandwich", "Huevos revueltos", "Entomatadas", "Chuletas", "Enchiladas",
  };
  private readonly string[] Ingredients = new string[]
  {
    "Lechuga", "Canela", "Pimienta", "Sal", "Tortilla de harina", "Tortilla maiz", "Tomate verde", "Huevo", "Chuleta", "Jamon", "Queso", "Espinaca",
  };

  private readonly ILogger<RecipeController> _logger;
  private readonly DataContext _dataContext;

  public RecipeController(ILogger<RecipeController> logger, DataContext dataContext)
  {
    _logger = logger;
    this._dataContext = dataContext;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Recipe>>> Get()
  {
    var recipes = await this._dataContext.Recipes
                    .Include(r => r.Ingredients).ToListAsync();
    return Ok(recipes);
  }
}
