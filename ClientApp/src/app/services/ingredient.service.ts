import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ServiceResponse } from '../interfaces/ServiceResponse';
import { Ingredient } from '../interfaces/Ingredient';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  private endpointUrl = 'api/ingredient';  // URL to web api

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  /** GET Ingredients from the server */
  getAll(): Observable<ServiceResponse<Ingredient[]>> {
   return this.http.get<ServiceResponse<Ingredient[]>>(this.endpointUrl)
     .pipe(
       tap(_ => this.log('fetched ingredients')),
       catchError(this.handleError<ServiceResponse<Ingredient[]>>('getAll'))
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

 /** Log a IngredientService message with the MessageService */
 private log(message: string) {
   // this.messageService.add(`IngredientService: ${message}`);
 }
}
