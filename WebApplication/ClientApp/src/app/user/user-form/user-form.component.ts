import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormControl,FormGroup, Validators} from '@angular/forms';
import {Router, ActivatedRoute} from '@angular/router';
import { DatePipe } from '@angular/common';
import { UserService } from 'src/app/services/user.service';
import { IUser } from 'src/app/models/user';
import { RoleType } from 'src/app/models/roleType';


@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css'],
  providers: [DatePipe]
})
export class UserFormComponent {
  userForm = new FormGroup({
    firstNameFormControl:new FormControl('',Validators.required),
    lastNameFormControl:new FormControl('',Validators.required),
    emailFormControl:new FormControl('',Validators.required),
    passwordFormControl:new FormControl('',Validators.required),
    roleFormControl:new FormControl('',Validators.required)
  });

  userId:number;
  isEdit: boolean=false;
  firstName: string;
  lastName: string;
  password: string;
  role: number = 2;
  email: string;

  constructor(
              protected route: Router,
              private activatedRoute:ActivatedRoute,
              private userService: UserService){ 

    this.activatedRoute.params.subscribe(
      params => {
        this.userId=params['id'];
        
        if( !isNaN(this.userId)  )
        {
          this.isEdit =true;
          this.userService.getById(this.userId)
          .subscribe(
              u => this.cargarFormulario(u),
              error=> console.error(error)
            );
        }
      });
  }

  cargarFormulario(user:IUser){
      this.firstName = user.firstName;
      this.lastName = user.lastName;
      this.email = user.email;
      this.password = user.password;
      this.role = user.role;
  }

  save(){
    this.validateFormGroup(this.userForm);
      if(this.userForm.valid){
        var  user :IUser;
        user={
          id:0,
          firstName:this.firstName,
          lastName:this.lastName,
          email:this.email,
          password:this.password,
          role:  parseInt(this.role.toString()),
          createdBy:undefined,
          createdDate:undefined,
          updateBy:undefined,
          updateDate:undefined,
          userName: this.email};

        if(this.isEdit){
          user.id = this.userId
          this.userService.update(user).subscribe( r =>{
                        this.route.navigate(['/users'])
                        alert("User Updated") 
                        }, error=> alert("Error Encounter at update"));
        }else{
          this.userService.create(user).subscribe(()=>{
                        alert("User Created Succesfully")
                        this.route.navigate(['/users'])
                        },error=> alert("Error Encounter at creation"));
        }
      }
    }

    private validateFormGroup(formGroup: FormGroup) {
      for (const i in formGroup.controls) {
        if (formGroup.controls.hasOwnProperty(i)) {
          formGroup.controls[i].markAsDirty();
          formGroup.controls[i].updateValueAndValidity();
        }
      }
    }

}
