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

    public RecipeController(ILogger<RecipeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<Recipe>> Get()
    {
        var recipes = Enumerable.Range(1, 50).Select(index => new Recipe
        {
            Name = Recipes[Random.Shared.Next(Recipes.Length)],
            Difficulty = Difficulty.Hard,
            PeopleCount = Random.Shared.Next(1,10),
            Time = new TimeSpan(Random.Shared.Next(1,23), Random.Shared.Next(1,59), Random.Shared.Next(1,59)),
            Ingredients = Enumerable.Range(1, 20).Select(index => new IngredientQuantity
            {
                Ingredient = new Ingredient
                {
                    Name = Ingredients[Random.Shared.Next(Ingredients.Length)],
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
