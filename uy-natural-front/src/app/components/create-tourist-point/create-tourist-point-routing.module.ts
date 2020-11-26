import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {CreateTouristPointComponent} from "./create-tourist-point.component";

const routes: Routes = [
  {path: '', component: CreateTouristPointComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateTouristPointRoutingModule {
}
