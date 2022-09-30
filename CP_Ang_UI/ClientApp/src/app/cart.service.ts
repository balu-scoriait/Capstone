import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ICart } from './ICart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  removeCarItem: any;
    removeAllCart: any;
    getTotalPrice: any;
  getproducts: any;
  deleteproduct: any;
  constructor(private http: HttpClient) { }
  addtoCart(cart: ICart) {
    return this.http.post<string>("http://alphacart.com/cart/addtocart", cart);
  }
  getcart(): Observable<ICart[]> {
    return this.http.get<ICart[]>("http://alphacart.com/cart")
  }
}
