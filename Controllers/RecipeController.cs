using Microsoft.AspNetCore.Mvc;
using Recipes.Models;

namespace Recipes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;

    public RecipeController(ILogger<RecipeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Recipe> Get()
    {
        var recipes = Enumerable.Range(1, 50).Select(index => new Recipe
        {
            Name = "Frijoles",
            Difficulty = Difficulty.Hard,
            PeopleCount = Random.Shared.Next(1,10),
            Time = new Time
            {
                Hours = Random.Shared.Next(1,23),
                Minutes  = Random.Shared.Next(1,59),
            },
            Ingredients = Enumerable.Range(1, 20).Select(index => new IngredientQuantity
            {
                Ingredient = new Ingredient
                {
                    Name = "Espinaca",
                    Kind = KindIngredient.None,
                },
                Quantity = new Quantity
                {
                    Count  = Random.Shared.Next(1,23),
                    Kind = KindQuantity.None,
                },
            }).ToArray(),
        });
        return recipes.ToArray();
    }
}
