import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {CreateReviewComponent} from "./create-review.component";

const routes: Routes = [
  {path: '', component: CreateReviewComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateReviewRoutingModule {
}
