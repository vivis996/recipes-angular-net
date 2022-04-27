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

  [HttpGet]
  [Route("{id}")]
  public async Task<ActionResult<Recipe>> Get(int id)
  {
    var recipe = await this._dataContext.Recipes
                    .Include(r => r.Ingredients)
                    .FirstOrDefaultAsync(r => r.Id == id);
    return Ok(recipe);
  }

  [HttpPost]
  public async Task<ActionResult<Recipe>> Post([FromBody]Recipe newRecipe)
  {
    this._dataContext.Recipes.Add(newRecipe);
    await this._dataContext.SaveChangesAsync();
    return Ok(newRecipe);
  }

  [HttpPost]
  public async Task<ActionResult<Recipe>> Put([FromBody]Recipe updatedRecipe)
  {
    var recipe = await this._dataContext.Recipes.FindAsync(updatedRecipe.Id);
    if (recipe == null)
    {
      throw new NullReferenceException("Recipe not found.");
    }
    recipe.Name = updatedRecipe.Name;
    recipe.Difficulty = updatedRecipe.Difficulty;
    recipe.PeopleCount = updatedRecipe.PeopleCount;
    recipe.Time = updatedRecipe.Time;

    await this._dataContext.SaveChangesAsync();
    return Ok(updatedRecipe);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<IEnumerable<Recipe>>> Delete(int id)
  {
    var recipe = await this._dataContext.Recipes.FindAsync(id);
    if (recipe == null)
    {
      throw new NullReferenceException("Recipe not found.");
    }

    this._dataContext.Recipes.Remove(recipe);
    await this._dataContext.SaveChangesAsync();

    return await this.Get();
  }
}
