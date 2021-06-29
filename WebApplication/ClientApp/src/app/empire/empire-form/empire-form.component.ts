import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormControl,FormGroup, Validators} from '@angular/forms';
import {Router, ActivatedRoute} from '@angular/router';
import { DatePipe } from '@angular/common';
import { IUser } from 'src/app/models/user';
import { IEmpire } from 'src/app/models/empire';
import { ICity } from 'src/app/models/city';
import { EmpireService } from 'src/app/services/empire.service';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-empire-form',
  templateUrl: './empire-form.component.html',
  styleUrls: ['./empire-form.component.css'],
  providers: [DatePipe]
})
export class EmpireFormComponent implements OnInit {
  empireForm = new FormGroup({
    nameFormControl:new FormControl('',Validators.required),
    userFormControl:new FormControl('',Validators.required),
    raceFormControl:new FormControl('',Validators.required),
  });

  empireId:number;
  name : string;
  user : IUser;
  userId: number = 0;
  race: number = 0;
  isEdit: boolean=false;
  cities: ICity[];
  users: IUser[];

  constructor(
              protected route: Router,
              private activatedRoute:ActivatedRoute,
              private empireService: EmpireService,
              private userService:UserService){ 

    this.activatedRoute.params.subscribe(
      params => {
        this.empireId=params['id'];
        
        if( !isNaN(this.empireId)  )
        {
          this.isEdit =true;
          this.empireService.getById(this.empireId)
          .subscribe(
              u => this.cargarFormulario(u),
              error=> console.error(error)
            );
        }
      });
  }

  ngOnInit() {
    this.userService.get().subscribe(u =>{
      this.users = u
    }); 
  }

  cargarFormulario(empire:IEmpire){
    this.name = empire.name;
    this.user = empire.user;
    this.userId = empire.userId;
    this.race = empire.id;
    this.cities = empire.cities;
  }

  save(){
    this.validateFormGroup(this.empireForm);
      if(this.empireForm.valid){
        var  empire :IEmpire;
        empire={
          id:0,
          name: this.name,
          user: undefined,
          userId: parseInt(this.userId.toString()),
          race: parseInt(this.race.toString()),
          cities: this.cities,
          createdBy:undefined,
          createdDate:undefined,
          updateBy:undefined,
          updateDate:undefined,};

        if(this.isEdit){
          empire.id = this.empireId
          this.empireService.update(empire).subscribe( r =>{
                        this.route.navigate(['/empires'])
                        alert("Empire Updated") 
                        }, error=> alert("Error Encounter at update"));
        }else{
          this.empireService.create(empire).subscribe(()=>{
                        alert("Empire Created Succesfully")
                        this.route.navigate(['/empires'])
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
