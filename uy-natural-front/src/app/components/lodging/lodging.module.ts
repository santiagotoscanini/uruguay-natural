import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {CreateLodgingComponent} from "./create-lodging/create-lodging.component";
import {LodgingRoutingModule} from "./lodging-routing.module";
import {DeleteLodgingComponent} from "./delete-lodging/delete-lodging.component";
import {EditLodgingComponent} from "./edit-lodging/edit-lodging.component";
import {MigrateLodgingsComponent} from "./migrate-lodgings/migrate-lodgings.component";
import {ReportComponent} from "./report/report.component";



@NgModule({
  imports: [
    CommonModule,
    NavbarModule,
    FormsModule,
    LodgingRoutingModule
  ],
  declarations: [
    CreateLodgingComponent,
    DeleteLodgingComponent,
    EditLodgingComponent,
    MigrateLodgingsComponent,
    ReportComponent,
  ],
})
export class LodgingModule { }
