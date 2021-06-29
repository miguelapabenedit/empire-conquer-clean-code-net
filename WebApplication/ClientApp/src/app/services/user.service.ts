import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../models/user';
import { BaseHttpService } from './base-http.service';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseHttpService<IUser> {


  constructor(httpClient: HttpClient,@Inject('BASE_URL') private baseUrl: string) {
    super(httpClient,baseUrl,'api/v1/user');
  }

  getUsers() {
    return this.get();
  }

  logIn(credentials:IUser):Observable<IUser>{
    const headers={
      'Accept':'application/json',
      'Content-Type':'application/json',
    }

    return this.httpClient.post<any>(this.baseUrl+'api/v1/Login',credentials,{headers});
  }

  isLoggedIn():boolean {
    return false;
  }
}
