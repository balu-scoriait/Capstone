import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  AuthService: any;
  constructor(private authService: AuthenticationService, private rout: Router) { }



  ngOnInit(): void {
    this.authService.isLogin.next(false);
    this.rout.navigate(['/homes']);
  }

}
