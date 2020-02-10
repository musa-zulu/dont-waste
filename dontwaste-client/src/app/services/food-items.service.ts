import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ServerConfig } from './server-config';
import { Observable } from 'rxjs';
import { FoodCategory } from '../models/food-category';
import { retry, catchError } from 'rxjs/operators';
import { FoodItem } from '../models/food-item';

@Injectable({
  providedIn: 'root'
})
export class FoodItemsService {

  private readonly apiURL = 'foodItems';

  constructor(private http: HttpClient,
              private serverConfig: ServerConfig) { }

  public getFoodItems(): Observable<any>  {
    return this.http
        .get<FoodItem[]>(this.serverConfig.getBaseUrl() +  this.apiURL, this.serverConfig.getRequestOptions())
        .pipe(
          retry(1),
          catchError(this.handleError));
  }

  getFoodItem(foodItemId: any): FoodItem {
    throw new Error("Method not implemented.");
  }

  deleteFoodItem(foodItemId: any) {
    throw new Error("Method not implemented.");
  }
  updateFoodItem(foodItem: any) {
    throw new Error("Method not implemented.");
  }

  public addFoodItem(foodItem: FoodItem): Promise<any> {
    return this.http
    .post(this.serverConfig.getBaseUrl() + this.apiURL, foodItem, this.serverConfig.getRequestOptions())
    .toPromise();
  }

  private handleError(error: any) {
    // tslint:disable-next-line: deprecation
    return Observable.throw(error);
  }

  /*createImagePath(serverPath: string) {
    return this.http
    .post(this.serverConfig.getBaseUrl() +
    `Updload`, this.serverConfig.getRequestOptions())
    .toPromise();
  }*/
}
