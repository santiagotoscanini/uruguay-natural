import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {EditBookingStateComponent} from "./edit-booking-state.component";
import {EditBookingStateRoutingModule} from "./edit-booking-state-routing.module";



@NgModule({
  imports: [
    CommonModule,
    NavbarModule,
    FormsModule,
    EditBookingStateRoutingModule,
  ],
  declarations: [EditBookingStateComponent],
})
export class EditBookingStateModule { }
