import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-homes',
  templateUrl: './homes.component.html',
  styleUrls: ['./homes.component.css']
})
export class HomesComponent implements OnInit {

  isLoggedInCheck: Boolean = false;
  un: string = '';
  constructor(private authService: AuthenticationService) { }
  ngOnInit(): void {
    this.authService.isLogin.subscribe((d) => { this.isLoggedInCheck = d;});
    this.authService.username.subscribe((d) => { this.un = d; });
  }
}
