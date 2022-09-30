import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomesComponent } from './project1/homes/homes.component';
import { LoginComponent } from './project1/login/login.component';
import { LogoutComponent } from './project1/logout/logout.component';
import { RegistrationComponent } from './project1/registration/registration.component';

import { CartListComponent } from './project1/cart-list/cart-list.component';
import { HeaderComponent } from './header/header.component';
import { ProductListComponent } from './project1/product-list/product-list.component';
import { ExampleLoginComponent } from './example-login/example-login.component';
import { ProductService } from './product.service';
import { ProductResolverService } from './product-resolver.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HomesComponent,
    LoginComponent,
    LogoutComponent,
    RegistrationComponent,
    ProductListComponent,
    CartListComponent,
    HeaderComponent,
    ExampleLoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, ReactiveFormsModule, MatPaginatorModule, MatTableModule, MatIconModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
      { path: 'Registration', component: RegistrationComponent },
      { path: 'homes', component: HomesComponent },
      { path: 'Cart', component: CartListComponent },

      { path: 'logout', component: LogoutComponent },

      { path: 'ProductList', component: ProductListComponent, resolve: { products: ProductResolverService } },

      
    ]),
    RouterModule,
    BrowserAnimationsModule
  ],
  providers: [ProductService, ProductResolverService],
  bootstrap: [AppComponent]
})
export class AppModule { }
