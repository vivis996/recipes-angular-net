using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.RecipeService;

namespace Recipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
  private readonly ILogger<RecipeController> _logger;
  private readonly IRecipeService _recipeService;

  public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
  {
    _logger = logger;
    this._recipeService = recipeService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Recipe>>> Get()
  {
    return Ok(await this._recipeService.GetAll());
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<ActionResult<Recipe>> Get(int id)
  {
    return Ok(await this._recipeService.GetById(id));
  }

  [HttpPost]
  public async Task<ActionResult<Recipe>> Post([FromBody]Recipe newRecipe)
  {
    return Ok(await this._recipeService.AddNewObject(newRecipe));
  }

  [HttpPost]
  public async Task<ActionResult<Recipe>> Put([FromBody]Recipe updatedRecipe)
  {
    return Ok(await this._recipeService.AddNewObject(updatedRecipe));
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<IEnumerable<Recipe>>> Delete(int id)
  {
    return Ok(await this._recipeService.DeleteObject(id));
  }
}
