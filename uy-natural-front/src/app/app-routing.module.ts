import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {HomeComponent} from "./components/home/home.component";
import {AuthGuard} from "./services/guards/auth.guard";

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'home', component: HomeComponent},
  {path: 'login', component: HomeComponent, loadChildren: () => import('./components/login/login.module').then(mod => mod.LoginModule)},
  {path: 'administrator', component: HomeComponent, loadChildren: () => import('./components/administrator/administrator.module').then(mod => mod.AdministratorModule), canActivate: [AuthGuard]},
  {path: 'lodging', component: HomeComponent, loadChildren: () => import('./components/lodging/lodging.module').then(mod => mod.LodgingModule), canActivate:[AuthGuard]},
  {path: 'tourist-point/create', component: HomeComponent, loadChildren: () => import('./components/create-tourist-point/create-tourist-point.module').then(mod => mod.CreateTouristPointModule), canActivate:[AuthGuard]},
  {path: 'booking/edit-state', component: HomeComponent, loadChildren: () => import('./components/edit-booking-state/edit-booking-state.module').then(mod => mod.EditBookingStateModule), canActivate:[AuthGuard]},
  {path: 'booking/check-status', component: HomeComponent, loadChildren: () => import('./components/check-booking-status/check-booking-status.module').then(mod => mod.CheckBookingStatusModule)},
  {path: 'booking/review', component: HomeComponent, loadChildren: () => import('./components/create-review/create-review.module').then(mod => mod.CreateReviewModule)},
  {path: 'booking', component: HomeComponent, loadChildren: () => import('./components/create-booking/create-booking.module').then(mod => mod.CreateBookingModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
