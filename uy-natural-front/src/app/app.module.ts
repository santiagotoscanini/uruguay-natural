import {NgModule} from '@angular/core';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {FormsModule} from "@angular/forms";

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {RegionService} from "./services/region.service";
import {CategoryService} from "./services/category.service";
import {HomeComponent} from './components/home/home.component';
import {SessionService} from "./services/session.service";
import {AdministratorService} from "./services/administrator.service";
import {NavbarService} from "./services/navbar.service";
import {AuthInterceptor} from "./services/http-interceptors/auth-interceptor";
import {CommonModule} from "@angular/common";
import {HandlerError} from './services/handler-error/handler-error';
import {AuthGuard} from "./services/guards/auth.guard";
import {NavbarModule} from "./components/navbar/navbar.module";
import {BrowserModule} from "@angular/platform-browser";

@NgModule({
  imports: [
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,

    BrowserModule,
    NavbarModule,
  ],
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  providers: [
    RegionService,
    CategoryService,
    SessionService,
    AdministratorService,
    NavbarService,
    HandlerError,
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule {
}
