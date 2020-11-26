import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarService} from "../../services/navbar.service";
import {NavbarComponent} from "./navbar.component";
import {BrowserModule} from "@angular/platform-browser";
import {AppRoutingModule} from "../../app-routing.module";
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";



@NgModule({
  declarations: [
    NavbarComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
  ],
  providers: [
    NavbarService,
  ],
  exports: [NavbarComponent]
})
export class NavbarModule { }
