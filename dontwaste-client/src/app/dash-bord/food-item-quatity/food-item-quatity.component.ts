import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCartService } from 'src/app/services/shopping-cart.service';
import { FoodItem } from 'src/app/models/food-item';

@Component({
  selector: 'app-food-item-quatity',
  templateUrl: './food-item-quatity.component.html',
  styleUrls: ['./food-item-quatity.component.css']
})
export class FoodItemQuatityComponent implements OnInit {
  // tslint:disable-next-line: no-input-rename
  @Input('foodItem') foodItem: FoodItem;
  // tslint:disable-next-line: no-input-rename
  @Input('shopping-cart') shoppingCart;

  constructor(private cartService: ShoppingCartService) { }

  addToCart() {
    this.cartService.addToCart(this.foodItem);
  }

  removeFromCart() {
    this.cartService.removeFromCart(this.foodItem);
  }

  ngOnInit(): void {
  }

}