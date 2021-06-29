import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private _baseUrl : string = this.baseUrl + 'api/v1/login';
  constructor(
    protected httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {}


  logIn(credentials:IUser){
    const headers={
      'Accept':'application/json',
      'Content-Type':'application/json',
    }

    this.httpClient.post<any>(this._baseUrl,credentials,{headers})
      .subscribe(response => {
        const token = response.token;
        localStorage.setItem('jwt',token)
      });
  }

  logOut(){
    localStorage.removeItem('jwt');
  }
}
