import { Component, OnInit, Input } from '@angular/core';
import { ShoppingCart } from 'src/app/models/shopping-cart';

@Component({
  selector: 'app-shopping-card-summary',
  templateUrl: './shopping-card-summary.component.html',
  styleUrls: ['./shopping-card-summary.component.css']
})
export class ShoppingCardSummaryComponent {
  // tslint:disable-next-line: no-input-rename
  cart: ShoppingCart = new ShoppingCart();

  get itemsCount() {
    return localStorage.length;
  }

  get getCart() {
    return this.cart.items;
  }

}
