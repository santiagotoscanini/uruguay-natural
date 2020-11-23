import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {FormsModule} from "@angular/forms";

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {RegionService} from "./services/region.service";
import {CategoryService} from "./services/category.service";
import {LoginComponent} from './components/login/login.component';
import {NavbarComponent} from './components/navbar/navbar.component';
import {HomeComponent} from './components/home/home.component';
import {CreateAdministratorComponent} from './components/administrator/create-administrator/create-administrator.component';
import {SessionService} from "./services/session.service";
import {AdministratorService} from "./services/administrator.service";
import {NavbarService} from "./services/navbar.service";
import {AuthInterceptor} from "./services/http-interceptors/auth-interceptor";
import {DeleteAdministratorComponent} from './components/administrator/delete-administrator/delete-administrator.component';
import {EditAdministratorComponent} from './components/administrator/edit-administrator/edit-administrator.component';
import {CreateLodgingComponent} from './components/lodging/create-lodging/create-lodging.component';
import {DeleteLodgingComponent} from './components/lodging/delete-lodging/delete-lodging.component';
import {EditLodgingComponent} from './components/lodging/edit-lodging/edit-lodging.component';
import { CreateTouristPointComponent } from './components/create-tourist-point/create-tourist-point.component';
import { EditBookingStateComponent } from './components/edit-booking-state/edit-booking-state.component';
import { ReportComponent } from './components/report/report.component';
import {CommonModule} from "@angular/common";
import { CheckBookingStatusComponent } from './components/check-booking-status/check-booking-status.component';
import { CreateReviewComponent } from './components/create-review/create-review.component';
import { SearchTouristPointComponent } from './components/create-booking/search-tourist-point/search-tourist-point.component';
import { SearchLodgingComponent } from './components/create-booking/search-lodging/search-lodging.component';
import { LodgingInfoComponent } from './components/create-booking/lodging-info/lodging-info.component';
import { SubmitBookingInfoComponent } from './components/create-booking/submit-booking-info/submit-booking-info.component';
import { BookingConfirmationInfoComponent } from './components/create-booking/booking-confirmation-info/booking-confirmation-info.component';
import { MigrateLodgingsComponent } from './components/lodging/migrate-lodgings/migrate-lodgings.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    NavbarComponent,
    HomeComponent,
    CreateAdministratorComponent,
    DeleteAdministratorComponent,
    EditAdministratorComponent,
    CreateLodgingComponent,
    DeleteLodgingComponent,
    EditLodgingComponent,
    CreateTouristPointComponent,
    EditBookingStateComponent,
    ReportComponent,
    CheckBookingStatusComponent,
    CreateReviewComponent,
    SearchTouristPointComponent,
    SearchLodgingComponent,
    LodgingInfoComponent,
    SubmitBookingInfoComponent,
    BookingConfirmationInfoComponent,
    MigrateLodgingsComponent,
  ],
  providers: [
    RegionService,
    CategoryService,
    SessionService,
    AdministratorService,
    NavbarService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule {
}
