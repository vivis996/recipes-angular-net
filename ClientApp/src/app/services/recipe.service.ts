import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServiceResponse } from '../interfaces/ServiceResponse';
import { Recipe } from '../interfaces/Recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  private recipesUrl = 'api/recipe';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

   /** GET Recipes from the server */
   getRecipes(): Observable<ServiceResponse<Recipe[]>> {
    return this.http.get<ServiceResponse<Recipe[]>>(this.recipesUrl)
      .pipe(
        tap(_ => this.log('fetched recipes')),
        catchError(this.handleError<ServiceResponse<Recipe[]>>('getRecipes'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a RecipeService message with the MessageService */
  private log(message: string) {
    // this.messageService.add(`RecipeService: ${message}`);
  }
}
