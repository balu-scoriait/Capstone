import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { CartService } from '../cart.service';
import { IProduct } from './product-list/IProduct';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  public isLogin: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public username: BehaviorSubject<string> = new BehaviorSubject<string>('');
  public cartcount: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  constructor(private router: Router, private cartService: CartService, private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  login(accessToken: string, AccessTokenExpirationDate: string, username: string) {
    console.log("true----------------->", this.isLogin.value);
    this.isLogin.next(true);
    localStorage.setItem('AccessToken', accessToken);
    localStorage.setItem('AccessTokenExpirationDate', AccessTokenExpirationDate);
    localStorage.setItem('UserName', username);
    this.username.next(username);
    console.log("LoggedIn Value : " + this.isLogin.value);
    this.router.navigate(['/ProductList']);
  }

  private hasToken(): boolean {
    return !localStorage.getItem('AccessToken');
  }
  getproducts(): Observable<IProduct[]> {
    return this.httpClient.get<IProduct[]>("http://localhost:5137/Products");
  }






}
