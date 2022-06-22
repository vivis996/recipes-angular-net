import { Component, OnInit } from '@angular/core';
import { Recipe } from '../interfaces/Recipe';
import { ServiceResponse } from '../interfaces/ServiceResponse';
import { RecipeService } from '../services/recipe.service';

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
})
export class RecipesComponent implements OnInit {

  recipes:  = [];

  constructor(private recipeService: RecipeService) { }

  ngOnInit(): void {
    this.getRecipes();
  }

  getRecipes(): void {
    this.recipeService.getAll()
      .subscribe((response: ServiceResponse<Recipe[]>) => this.recipes = response.data);
  }
}
