import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTableModule, MatInputModule, MatButtonModule, MatFormFieldModule, MatDialogModule } from '@angular/material';
import { CustomFormsModule } from 'ng2-validation';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FoodCategoriesListComponent } from './dash-bord/food-categories/food-categories-list/food-categories-list.component';
import { FoodCategoriesService } from './services/food-categories.service';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HttpClientModule } from '@angular/common/http';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { FoodCategoriesFilterComponent } from './dash-bord/food-categories-filter/food-categories-filter.component';
import { FormsModule } from '@angular/forms';
import { DialogBoxComponent } from './dash-bord/food-categories/dialog-box/dialog-box.component';
import { DashBordComponent } from './dash-bord/dash-bord.component';
import { ShoppingCardSummaryComponent } from './dash-bord/shopping-card-summary/shopping-card-summary.component';
import { FoodItemsComponent } from './dash-bord/food-items/food-items.component';
import { FoodItemsCardComponent } from './dash-bord/food-items-card/food-items-card.component';
import { FoodItemsListComponent } from './dash-bord/food-items/food-items-list/food-items-list.component';
import { ConfirmationDialogComponent } from './dash-bord/confirmation-dialog/confirmation-dialog.component';
import { FoodItemsService } from './services/food-items.service';
import { ShoppingCartService } from './services/shopping-cart.service';
import { OrdersComponent } from './dash-bord/orders/orders.component';
import { ShoppingCartComponent } from './dash-bord/shopping-cart/shopping-cart.component';

@NgModule({
  declarations: [
    AppComponent,
    FoodCategoriesListComponent,
    NavBarComponent,
    FoodCategoriesFilterComponent,
    DialogBoxComponent,
    DashBordComponent,
    ShoppingCardSummaryComponent,
    FoodItemsComponent,
    FoodItemsCardComponent,
    FoodItemsListComponent,
    ConfirmationDialogComponent,
    OrdersComponent,
    ShoppingCartComponent,
  ],
  imports: [
    FormsModule,
    CustomFormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    NgbModule,
    AngularFontAwesomeModule,
    MatTableModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  entryComponents: [
    DialogBoxComponent,
    ConfirmationDialogComponent
  ],
  providers: [FoodCategoriesService,
    ConfirmationDialogComponent,
     FoodItemsService,
     ShoppingCartService],
  bootstrap: [AppComponent]
})
export class AppModule { }
