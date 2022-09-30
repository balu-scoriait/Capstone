import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from './project1/authentication.service';
import { IProduct } from './project1/product-list/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductResolverService implements Resolve<IProduct[]> {

  constructor(private validate: AuthenticationService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): IProduct[] | Observable<IProduct[]> | Promise<IProduct[]> {
    return this.validate.getproducts();
    }
  
}
