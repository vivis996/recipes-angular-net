import { Component, OnInit } from '@angular/core';
import { Ingredient } from '../interfaces/Ingredient';
import { IngredientService } from '../services/ingredient.service';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
})
export class IngredientsComponent implements OnInit {

  ingredients: Ingredient[] = [];

  constructor(private ingredientService: IngredientService) { }

  ngOnInit(): void {
    this.getIngredients();
  }

  getIngredients(): void {
    this.ingredientService.getAll()
      .subscribe(response => this.ingredients = response.data);
  }
}
