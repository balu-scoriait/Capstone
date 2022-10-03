import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from './IProduct';
import { ApiService } from '../../api.service';
import { CartService } from '../../cart.service';
import { ProductService } from '../../product.service';
import { AuthenticationService } from '../authentication.service';
import { ICart } from '../../ICart';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: IProduct[] = [];
  cart: ICart | any;
  items: any;
  totalItem: number = 0;
  retVal: string = '';
  constructor(private _productService: ProductService, private atr: ActivatedRoute, private cartservice: CartService, private auth: AuthenticationService) {
this.products = this.atr.snapshot.data['products'];
this.cart = {
  productID: 1,
  productName: 'X',
  productPrice: 123,
  imageUrl: 'X',
  productQty: 1,
  totalPrice: 123,
  username: ''
  };
  }

  ngOnInit(): void { }

  addcart(productID: number, productName: string, productPrice: number, imageUrl: string) {
    this.cart = { username: localStorage.getItem('UserName')?.toString(), productID: productID, productName: productName, productPrice: productPrice, imageUrl: imageUrl, productQty: 1, totalPrice: 25000 };
    console.log(productID);
    this.cartservice.addtoCart(this.cart).subscribe((d) => {
      this.retVal = d;
      console.log(this.cart);
      this.auth.cartcount.subscribe((r) => { this.totalItem = r; });
      this.auth.cartcount.next(this.totalItem + 1);
      alert('Product Added Successfully!');
    });
  }
  }
        
    

