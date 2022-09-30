import { HttpClient, HttpHeaders } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IUser } from '../../../../IUser';
import { ApiService } from '../../api.service';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  accessToken: string | any;
  loginForm: FormGroup | any;
  user: IUser | any;
  retVal: string = '';
  next: any;
  public Status: boolean | any;
    rout: any;

  constructor(private fb: FormBuilder, private _router: Router, private authService: AuthenticationService,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private _Activatedroute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      name: [''],
      email: 'sdk@gmail.com',
      username: [''],
      password: [''],
      appcode: 'bwbjw'
    });

    this.accessToken = '';

  }
 
  onSubmit(): void {
    console.log("Testing for logging")
    this.http.post<string>(this.baseUrl + 'home/login', this.loginForm.value).subscribe((r) => {
      this.Status = r; console.log(r);
      this.retVal = r;

      if (r != null) {
        this.accessToken = JSON.stringify(r[0]);
        console.log("retVal[0] :" + this.accessToken);
        console.log("this.retVal[1] :" + JSON.stringify(r[1]));
        this.authService.login(this.accessToken, JSON.stringify(r[1]), this.loginForm.get("username").value);
        /*this._router.navigate(['homes']);*/
      }
    });
  }


        
}



  /*loginForm: FormGroup | any;
  constructor(private fb: FormBuilder, private authService: AuthenticationService, private rout: Router, private http: HttpClient) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: (['', Validators.required]),
      password: ['', Validators.required]
    })
  }
  loginClick(): void {
    this.http.get<any>("http://localhost:5117/api/Customer").subscribe((res: any[]) => {
      const user = res.find((a: any) => {
        return a.username === this.loginForm.value.username && a.password === this.loginForm.value.password
      })
      if (user) {
        alert("Login Successfully!");
        this.authService.username.next(this.loginForm.get('username').value);
        this.authService.isLogin.next(true);
        this.loginForm.reset();
        this.rout.navigate(['ProductList']);

      }
      else {
        alert("Wrong Credentials");
      }
    }, (err: any) => {
      alert("error");
    }
    )
  }
}

  *//* this.authService.username.next(this.loginForm.get('username').value);
  this.authService.isLogin.next(true);
   this.rout.navigate(['/ProductList']);
 }*//*


*/
