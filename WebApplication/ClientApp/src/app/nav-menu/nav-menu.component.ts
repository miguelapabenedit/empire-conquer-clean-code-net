import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLogged = false;
  /**
   *
   */

  constructor(
    protected route: Router,
    protected authService: AuthService){
    }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logOut (){
    this.isLogged = false;
    this.authService.logOut();
    this.route.navigate(['']);
  }
}
