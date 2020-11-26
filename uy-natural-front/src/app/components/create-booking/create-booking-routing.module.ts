import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {SearchTouristPointComponent} from "./search-tourist-point/search-tourist-point.component";
import {SearchLodgingComponent} from "./search-lodging/search-lodging.component";
import {LodgingInfoComponent} from "./lodging-info/lodging-info.component";
import {SubmitBookingInfoComponent} from "./submit-booking-info/submit-booking-info.component";
import {BookingConfirmationInfoComponent} from "./booking-confirmation-info/booking-confirmation-info.component";

const routes: Routes = [
  {path: '', redirectTo: 'search-tourist-point'},
  {path: 'search-tourist-point', component: SearchTouristPointComponent},
  {path: 'search-lodging/:touristPointId', component: SearchLodgingComponent},
  {path: 'lodging-info', component: LodgingInfoComponent},
  {path: 'submit-info', component: SubmitBookingInfoComponent},
  {path: 'confirmation', component: BookingConfirmationInfoComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateBookingRoutingModule {
}
