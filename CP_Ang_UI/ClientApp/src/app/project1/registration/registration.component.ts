import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from '../../../../IUser';
import { ApiService } from '../../api.service';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  registerForm: FormGroup | any;
  editData: any;
  user: IUser = { username: '', email: '', name: '', password: '', IsActive: '',RoleId:'' };
  ref: any;

  public status: boolean=false;
  constructor(private fb: FormBuilder, private http: HttpClient, private authService: AuthenticationService, private rout: Router, private api: ApiService,
    @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      name: (['', Validators.required]),
      email: (['', Validators.required]),
      username: (['', Validators.required]),
      password: (['', Validators.required]),
      appcode: 'Jhonnywick',
      IsActive:['0'],
      RoleId:['1']
    })
  }

  mapFormValuesToModel() {

    this.user = {
      email: this.registerForm.get('email').value,
      name: this.registerForm.get('name').value,
      password: this.registerForm.get('password').value,
      username: this.registerForm.get('username').value,
      IsActive: this.registerForm.get('IsActive').value,
      RoleId: this.registerForm.get('RoleId').value,
    }
    }


  registerClick(): void {

    
    if (this.registerForm.valid) {
      this.mapFormValuesToModel();
  
      console.log(this.user);
      //console.log(this.baseUrl + 'home/CreateUsers');
      this.http.post<boolean>(this.baseUrl + 'home/register', this.user).subscribe((r) => { this.status = r; console.log(r); });
      this.rout.navigate(['/login'])
      /*alert("Navigating to Login page on successful registration")
      this.authService.username.next(this.registerForm.get('username').value);*/
      }
      

      //alert("Navigating to Login page on successful registration")
      //this.authService.username.next(this.registerForm.get('username').value);

      //this.rout.navigate(['/login']);
    }

    /*updateCustomer() {
      this.api.putCustomer(this.registerForm.value).subscribe({
        next: (result: any) => {
          alert("Updated Successful");
          this.registerForm.reset();
          this.ref.close('update');
        }
      })
    }*/
    /*
  else {
    this.updateCustomer()
  }

  alert("Navigating to Login page on successful registration")
  this.authService.username.next(this.regForm.get('username').value);

  this.rout.navigate(['/login']);
}

updateCustomer() {
  this.api.putCustomer(this.regForm.value).subscribe({
    next: (result: any) => {
      alert("Updated Successful");
      this.regForm.reset();
      this.ref.close('update');
    }
  })
}
}*/

 /* accessToken: string | any;
  user: IUser | any;
  retVal: string = '';
  next: any;
  currentUserService: any;
  UserRegister: any;
  rout: any;
    registerForm: FormGroup | any;

  constructor(private fb: FormBuilder, private _router: Router, private authService: AuthenticationService,
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  ngOnInit(): void {
    console.log(this.baseUrl);
    const username = this.rout.snapshot.paramMap.get('username');
    this.registerForm = this.fb.group({
      
      name: ['', [Validators.required,]],
      email: ['', Validators.required],
     
      username: ['', Validators.required],
       password: ['', [Validators.required,]],
    });
    this.user = { username: username ? username : null, password: null,name:null,email:null };
    console.log(this.user);

    this.registerForm.patchValue({
      username: username ? username : '',
      password: ''
    });
    this.accessToken = '';

  }
  mapFormValuesToModel() {
    this.user.name = this.registerForm.get('name').value;
    this.user.email = this.registerForm.get('email').value;
    this.user.username = this.registerForm.get('useruame').value;
    this.user.password = this.registerForm.get('password').value;
  }

  onSubmit(): void {
    console.log(this.registerForm.value);

    this.mapFormValuesToModel();
    console.log(this.user);
    this.http.post<string>(this.baseUrl + 'Home/LoginUser', this.user, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(result => {
      console.log(result);

      this.retVal = result;
      if (result != null) {

        this.accessToken = JSON.stringify(result[0]);

        console.log(this.accessToken);
        console.log(JSON.stringify(result[1]));
       *//* console.log(JSON.stringify(result[2]));
        console.log(JSON.stringify(result[3]));
        console.log(JSON.stringify(result[4]));*//*





        this.currentUserService.login(this.accessToken, JSON.stringify(result[1]), this.user.username);

      }

    }, error => console.error(error));
    this.authService.username.next(this.registerForm.get('username').value);
    this.authService.isLogin.next(true);
    this.rout.navigate(['/login']);

  }*/
}






 /* registerForm: FormGroup | any;
  editData: any;

  ref: any;
  constructor(private fb: FormBuilder, private http: HttpClient, private authService: AuthenticationService, private rout: Router, private api: ApiService) { }

ngOnInit(): void {
    this.registerForm = this.fb.group({
      name: (['', Validators.required]),
      email: (['', Validators.required]),
      username: (['', Validators.required]),
      password: (['', Validators.required]),
    })
  }
  loginClick(): void {

    if (!this.editData) {
      if (this.registerForm.valid) {
        this.http.post < string>(this.registerForm.value).subscribe({
         next: (result: any) => {
            alert("Details added Successfully");
            this.regForm.reset();
            this.ref.close('save');
          },
          error: () => {
            alert("Error occured")
          }
        })
      }*/
    /*
    else {
      this.updateCustomer()
    }

    alert("Navigating to Login page on successful registration")
    this.authService.username.next(this.regForm.get('username').value);

    this.rout.navigate(['/login']);
  }

  updateCustomer() {
    this.api.putCustomer(this.regForm.value).subscribe({
      next: (result: any) => {
        alert("Updated Successful");
        this.regForm.reset();
        this.ref.close('update');
      }
    })
  }
}*/
