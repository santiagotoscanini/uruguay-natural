import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {CreateTouristPointComponent} from "./create-tourist-point.component";
import {CreateTouristPointRoutingModule} from "./create-tourist-point-routing.module";



@NgModule({
  imports: [
    CommonModule,
    NavbarModule,
    FormsModule,
    CreateTouristPointRoutingModule
  ],
  declarations: [CreateTouristPointComponent],
})
export class CreateTouristPointModule { }
