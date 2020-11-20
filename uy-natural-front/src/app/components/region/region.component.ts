import { Component, OnInit } from '@angular/core';
import {RegionService} from "../../services/region.service";
import {Region} from "../../models/Region";

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html',
  styleUrls: ['./region.component.scss']
})
export class RegionComponent implements OnInit {
  regions:Region[] = [];

  constructor(private regionService:RegionService) {}

  ngOnInit(): void {
    this.regionService.getRegions().subscribe(regionResponse => this.saveRegions(regionResponse), (error:string) => this.showError(error))
  }

  private saveRegions(regions:Region[]){
    this.regions = regions;
    console.log(JSON.stringify(this.regions));
  }

  private showError(message : string){
    console.log(message);
  }

  sayHello(){
    alert("holi");
  }

}
