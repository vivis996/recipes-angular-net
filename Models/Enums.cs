using System.Text.Json.Serialization;

namespace Recipes.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Difficulty
{
  None = 0,
  Easy = 1,
  Normal = 2,
  Hard = 3,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum KindIngredient
{
  None = 0,
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum KindQuantity
{
  None = 0,
}