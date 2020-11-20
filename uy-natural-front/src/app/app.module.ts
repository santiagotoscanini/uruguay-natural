import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule} from "@angular/forms";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegionComponent } from './components/region/region.component';
import { RegionService } from "./services/region.service";
import { CategoryService } from "./services/category.service";
import { CategoryComponent } from './components/category/category.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  declarations: [
    AppComponent,
    RegionComponent,
    CategoryComponent
  ],
  providers: [
    RegionService,
    CategoryService
  ],
  bootstrap: [AppComponent],
  exports: [RegionComponent]
})
export class AppModule { }
