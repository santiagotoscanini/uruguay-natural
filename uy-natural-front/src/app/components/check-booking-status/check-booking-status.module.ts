import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CreateBookingRoutingModule} from "../create-booking/create-booking-routing.module";
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {CheckBookingStatusComponent} from "./check-booking-status.component";
import {CheckBookingStatusRoutingModule} from "./check-booking-status-routing.module";



@NgModule({
  imports: [
    CommonModule,
    NavbarModule,
    FormsModule,
    CheckBookingStatusRoutingModule,
  ],
  declarations: [
    CheckBookingStatusComponent
  ],
})
export class CheckBookingStatusModule { }
