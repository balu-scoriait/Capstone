import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { CartService } from '../cart.service';
import { AuthenticationService } from '../project1/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedInCheck: Boolean = false;
  public username: any = localStorage.getItem('UserName');
  public totalItem: number = 0;




  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  constructor(private authService: AuthenticationService, private cart: CartService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }
  ngOnInit() {
    this.authService.isLogin.subscribe((d) => { this.isLoggedInCheck = d });
    if (this.isLoggedInCheck == true) {
      this.http.get<number>(this.baseUrl + 'home/getcartitemcount').subscribe((r) => {
        this.authService.cartcount.next(r);
        this.authService.cartcount.subscribe(d => { this.totalItem = d; })
      });
    }
  }
}
