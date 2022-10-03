import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ICart } from './ICart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  public productList = new BehaviorSubject<any>([]);
  public cartList: any = []
  constructor(private http: HttpClient) { }

addtoCart(cart: ICart)
{
return this.http.post<string>("http://localhost:5137/cart/addtocart", cart);
}


getcart(username : string)
{
  return this.http.get<any>("http://localhost:5137/cart/username?username=" + username);
}

deleteproduct(productID: number)
{
  return this.http.delete<any>("http://fake.alpha.com/api/cart/" + productID)
}

  removeAllCart() {

  }


}
