import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUser } from '../models/user';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})

export class LoginComponent {
  /**
   *
   */
  constructor(
    protected route: Router,
    private authService: AuthService,
  ) {

  }
  userForm = new FormGroup({
    emailFormControl:new FormControl('',Validators.required),
    passwordFormControl:new FormControl('',Validators.required),
  });

  public password: string;
  public email: string;

  public logIn(){
    var user : IUser = {
      email : this.email,
      password : this.password,
      createdBy: undefined,
      createdDate: undefined,
      firstName: undefined,
      id: undefined,
      lastName: undefined,
      role: undefined,
      updateBy:undefined,
      updateDate:undefined,
      userName: undefined,
    };

     this.authService.logIn(user);
  }
}
