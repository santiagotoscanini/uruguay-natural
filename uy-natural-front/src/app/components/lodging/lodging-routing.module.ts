import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {CreateLodgingComponent} from "./create-lodging/create-lodging.component";
import {EditLodgingComponent} from "./edit-lodging/edit-lodging.component";
import {DeleteLodgingComponent} from "./delete-lodging/delete-lodging.component";
import {ReportComponent} from "../lodging/report/report.component";
import {MigrateLodgingsComponent} from "./migrate-lodgings/migrate-lodgings.component";

const routes: Routes = [
  {path: '', redirectTo: 'create'},
  {path: 'create', component: CreateLodgingComponent},
  {path: 'edit', component: EditLodgingComponent},
  {path: 'delete', component:DeleteLodgingComponent},
  {path: 'report', component: ReportComponent},
  {path: 'migration', component: MigrateLodgingsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LodgingRoutingModule {
}
