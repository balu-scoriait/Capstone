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
  cart: ICart
  retVal: string = '';
  constructor(private _productService: ProductService, private atr: ActivatedRoute, private cartservice: CartService) {
    this.products = this.atr.snapshot.data['products']

    this.cart = { username:'',product_id: 1, product_name: 'product_name', product_price: 25000, image_url: 'image_url', product_quantity: 1, total_price: 25000 };
  }
  ngOnInit(): void {
    
     
      
  }
  addcart(product_id: number, product_name: string, product_price: number, image_url: string) {
    this.cart = { username: 'username',product_id: product_id, product_name: product_name, product_price: product_price, image_url: image_url, product_quantity: 1, total_price: 25000 }
    console.log(product_id);
    this.cartservice.addtoCart(this.cart).subscribe((d) => { this.retVal = d; console.log("XXXXXX------->"); console.log(d); alert('Product Added Successfully!'); });
  }
  }
        
    

