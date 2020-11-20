import { Component, OnInit } from '@angular/core';
import {Category} from "../../models/Category";
import {CategoryService} from "../../services/category.service";

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  categories : Category[] = []

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(categoryResponse => this.saveCategories(categoryResponse), (error:string) => this.showError(error))
  }

  private saveCategories(categories:Category[]){
    this.categories = categories;
    console.log(JSON.stringify(this.categories));
  }

  private showError(message : string){
    console.log(message);
  }
}
