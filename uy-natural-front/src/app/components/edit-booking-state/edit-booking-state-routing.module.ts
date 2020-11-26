import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {EditBookingStateComponent} from "./edit-booking-state.component";

const routes: Routes = [
  {path: '', component: EditBookingStateComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EditBookingStateRoutingModule {
}
