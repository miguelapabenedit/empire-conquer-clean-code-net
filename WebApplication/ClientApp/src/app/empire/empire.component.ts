import { Component, OnInit } from '@angular/core';
import { IEmpire } from '../models/empire';
import { RaceType } from '../models/raceType';
import { IUser } from '../models/user';
import { EmpireService } from '../services/empire.service';

@Component({
  selector: 'app-empire',
  templateUrl: './empire.component.html',
  styleUrls: ['./empire.component.css']
})
export class EmpireComponent implements OnInit {
  public empires: IEmpire[];

  constructor(private empireService: EmpireService) {
  }

  ngOnInit() {
    this.empireService.get().subscribe(e =>{
      this.empires = e
    }); 
  }

  delete(empireId:number){
    this.empireService.delete(empireId).subscribe( _ =>{
        this.empires = this.empires.filter(u => u.id != empireId);
    })
  }

  getRaceType(type:number){
    return RaceType[type];
  }
}