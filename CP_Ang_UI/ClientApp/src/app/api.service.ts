import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  /*getProduct() {
      throw new Error('Method not implemented.');
  }
  get<T>(arg0: string) {
      throw new Error('Method not implemented.');
  }*/

  constructor(private http: HttpClient, ) { }

  /*getCustomer() {
    return this.http.get<any>("http://localhost:5117/api/Customer/");
  }

  postCustomer(details: any) {
    return this.http.post<any>("http://localhost:5117/api/Customer/", details);
  }

  putCustomer(details: any) {
    return this.http.put<any>("http://localhost:5117/api/Customer/", details)
}*/


  
}


