import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CreateBookingRoutingModule} from "./create-booking-routing.module";
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {SearchTouristPointComponent} from "./search-tourist-point/search-tourist-point.component";
import {SearchLodgingComponent} from "./search-lodging/search-lodging.component";
import {LodgingInfoComponent} from "./lodging-info/lodging-info.component";
import {SubmitBookingInfoComponent} from "./submit-booking-info/submit-booking-info.component";
import {BookingConfirmationInfoComponent} from "./booking-confirmation-info/booking-confirmation-info.component";

@NgModule({
  imports: [
    CommonModule,
    CreateBookingRoutingModule,
    NavbarModule,
    FormsModule,
  ],
  declarations: [
    SearchTouristPointComponent,
    SearchLodgingComponent,
    LodgingInfoComponent,
    SubmitBookingInfoComponent,
    BookingConfirmationInfoComponent,
  ],
})
export class CreateBookingModule { }
