import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { EmpireComponent } from './empire/empire.component';
import { UserComponent } from './user/user.component';
import { UserFormComponent } from './user/user-form/user-form.component';
import { EmpireFormComponent } from './empire/empire-form/empire-form.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './login/guards/auth.guard';
import {JwtModule} from '@auth0/angular-jwt'

export function tokenGetter(){
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserComponent,
    UserFormComponent,
    EmpireComponent,
    LoginComponent,
    EmpireFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full'},
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: 'users', component: UserComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      { path: 'user/:id', component: UserFormComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      { path: 'user-create', component: UserFormComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      { path: 'empires', component: EmpireComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      { path: 'empire/:id', component: EmpireFormComponent, pathMatch: 'full', canActivate:[AuthGuard] },
      { path: 'empire-create', component: EmpireFormComponent, pathMatch: 'full', canActivate:[AuthGuard] },

    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains:['localhost:57078'],
        disallowedRoutes:[]
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
