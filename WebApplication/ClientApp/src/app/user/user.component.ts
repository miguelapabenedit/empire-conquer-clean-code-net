import { Component, OnInit } from '@angular/core';
import { RoleType } from '../models/roleType';
import { IUser } from '../models/user';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public users: IUser[];

  constructor(private userService: UserService) {
  }

  ngOnInit() {
    this.userService.get().subscribe(u =>{
      this.users = u
    }); 
  }

  delete(userId:number){
    this.userService.delete(userId).subscribe( _ =>{
        this.users = this.users.filter(u => u.id != userId);
    })
  }
  
  getRoleType(type:number){
    return RoleType[type];
  }
}
