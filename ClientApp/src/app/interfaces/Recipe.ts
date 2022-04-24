import { IngredientQuantity } from "./IngredientQuantity";
import { Time } from "./Time";

export interface Recipe {
  name: String;
  difficulty: number;
  peopleCount: number;
  time: Time;
  ingredients: IngredientQuantity[];
}
