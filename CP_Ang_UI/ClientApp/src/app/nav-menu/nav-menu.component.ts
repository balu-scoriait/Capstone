import { Component } from '@angular/core';
import { AuthenticationService } from '../project1/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedInCheck: Boolean = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  constructor(private authService: AuthenticationService) {

  }
  ngOnInit() {
    this.authService.isLogin.subscribe((d) => { this.isLoggedInCheck = d });
  }
}
