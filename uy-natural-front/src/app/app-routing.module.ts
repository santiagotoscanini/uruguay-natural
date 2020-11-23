import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {LoginComponent} from "./components/login/login.component";
import {HomeComponent} from "./components/home/home.component";
import {CreateAdministratorComponent} from "./components/administrator/create-administrator/create-administrator.component";
import {DeleteAdministratorComponent} from "./components/administrator/delete-administrator/delete-administrator.component";
import {EditAdministratorComponent} from "./components/administrator/edit-administrator/edit-administrator.component";
import {CreateLodgingComponent} from "./components/lodging/create-lodging/create-lodging.component";
import {EditLodgingComponent} from "./components/lodging/edit-lodging/edit-lodging.component";
import {DeleteLodgingComponent} from "./components/lodging/delete-lodging/delete-lodging.component";
import {CreateTouristPointComponent} from "./components/create-tourist-point/create-tourist-point.component";
import {EditBookingStateComponent} from "./components/edit-booking-state/edit-booking-state.component";
import {ReportComponent} from "./components/report/report.component";
import {CheckBookingStatusComponent} from "./components/check-booking-status/check-booking-status.component";
import {CreateReviewComponent} from "./components/create-review/create-review.component";
import {SearchTouristPointComponent} from "./components/create-booking/search-tourist-point/search-tourist-point.component";
import {SearchLodgingComponent} from "./components/create-booking/search-lodging/search-lodging.component";
import {LodgingInfoComponent} from "./components/create-booking/lodging-info/lodging-info.component";
import {SubmitBookingInfoComponent} from "./components/create-booking/submit-booking-info/submit-booking-info.component";
import {BookingConfirmationInfoComponent} from "./components/create-booking/booking-confirmation-info/booking-confirmation-info.component";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent},
  {path: 'administrator/create', component: CreateAdministratorComponent},
  {path: 'administrator/delete', component: DeleteAdministratorComponent},
  {path: 'administrator/edit', component: EditAdministratorComponent},
  {path: 'lodging/create', component: CreateLodgingComponent},
  {path: 'lodging/edit', component: EditLodgingComponent},
  {path: 'lodging/delete', component: DeleteLodgingComponent},
  {path: 'tourist-point/create', component: CreateTouristPointComponent},
  {path: 'booking/edit-state', component: EditBookingStateComponent},
  {path: 'report', component: ReportComponent},
  {path: 'booking/check-status', component: CheckBookingStatusComponent},
  {path: 'booking/review', component: CreateReviewComponent},
  {path: 'booking/search-tourist-point', component: SearchTouristPointComponent},
  {path: 'booking/search-lodging', component: SearchLodgingComponent},
  {path: 'booking/lodging-info', component: LodgingInfoComponent},
  {path: 'booking/submit-info', component: SubmitBookingInfoComponent},
  {path: 'booking/confirmation', component: BookingConfirmationInfoComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
