import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {CheckBookingStatusComponent} from "./check-booking-status.component";

const routes: Routes = [
  {path: '', component: CheckBookingStatusComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CheckBookingStatusRoutingModule {
}
