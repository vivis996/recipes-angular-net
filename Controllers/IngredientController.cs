using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.IngredientService;

namespace Recipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
  private readonly ILogger<IngredientController> _logger;
  private readonly IIngredientService _ingredientService;

  public IngredientController(ILogger<IngredientController> logger, IIngredientService ingredientService)
  {
    this._logger = logger;
    this._ingredientService = ingredientService;
  }

  [HttpGet]
  public async Task<ActionResult<ServiceResponse<List<Ingredient>>>> Get()
  {
    return Ok(await this._ingredientService.GetAll());
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<ActionResult<ServiceResponse<Ingredient>>> Get(int id)
  {
    return Ok(await this._ingredientService.GetById(id));
  }

  [HttpPost]
  public async Task<ActionResult<ServiceResponse<Ingredient>>> Post([FromBody]Ingredient newRecipe)
  {
    return Ok(await this._ingredientService.AddNewObject(newRecipe));
  }

  [HttpPost]
  public async Task<ActionResult<ServiceResponse<Ingredient>>> Put([FromBody]Ingredient updatedRecipe)
  {
    return Ok(await this._ingredientService.AddNewObject(updatedRecipe));
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<ServiceResponse<List<Ingredient>>>> Delete(int id)
  {
    return Ok(await this._ingredientService.DeleteObject(id));
  }
}
