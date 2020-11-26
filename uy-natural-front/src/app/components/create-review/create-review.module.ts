import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {CreateReviewComponent} from "./create-review.component";
import {CreateReviewRoutingModule} from "./create-review-routing.module";



@NgModule({
  imports: [
    CommonModule,
    NavbarModule,
    FormsModule,
    CreateReviewRoutingModule
  ],
  declarations: [
    CreateReviewComponent
  ],
})
export class CreateReviewModule { }
