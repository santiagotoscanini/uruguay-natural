import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {CreateAdministratorComponent} from "./create-administrator/create-administrator.component";
import {DeleteAdministratorComponent} from "./delete-administrator/delete-administrator.component";
import {EditAdministratorComponent} from "./edit-administrator/edit-administrator.component";

const routes: Routes = [
  {path: '', redirectTo: 'create'},
  {path: 'create', component: CreateAdministratorComponent},
  {path: 'delete', component: DeleteAdministratorComponent},
  {path: 'edit', component: EditAdministratorComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministratorRoutingModule {
}
