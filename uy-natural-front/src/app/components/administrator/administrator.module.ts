import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "../navbar/navbar.module";
import {FormsModule} from "@angular/forms";
import {CreateAdministratorComponent} from "./create-administrator/create-administrator.component";
import {AdministratorRoutingModule} from "./administrator-routing.module";
import {DeleteAdministratorComponent} from "./delete-administrator/delete-administrator.component";
import {EditAdministratorComponent} from "./edit-administrator/edit-administrator.component";



@NgModule({
  imports: [
    CommonModule,
    NavbarModule,
    FormsModule,
    AdministratorRoutingModule,
  ],
  declarations: [
    CreateAdministratorComponent,
    DeleteAdministratorComponent,
    EditAdministratorComponent,
  ],
})
export class AdministratorModule { }
