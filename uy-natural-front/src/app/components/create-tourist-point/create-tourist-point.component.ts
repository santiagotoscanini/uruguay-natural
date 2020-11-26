import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../services/navbar.service";
import {TouristPoint} from "../../models/touristPoint/TouristPoint";
import {TouristPointService} from "../../services/tourist-point.service";
import {CategoryService} from "../../services/category.service";
import {RegionService} from "../../services/region.service";
import {Category} from "../../models/category/Category";

@Component({
  selector: 'app-create-tourist-point',
  templateUrl: './create-tourist-point.component.html',
  styleUrls: ['./create-tourist-point.component.css']
})
export class CreateTouristPointComponent implements OnInit {

  constructor(public navbarService: NavbarService, private touristPointService: TouristPointService, private categoryService: CategoryService, private regionService: RegionService) {
  }

  regions = []
  categories = []

  selectedCategory: string = ""

  errorMessage:string
  saved: boolean = false

  touristPoint: TouristPoint = {
    name: "",
    categories: [],
    description: "",
    image: "",
    regionName: "",
  }

  ngOnInit(): void {
    this.getRegions();
    this.getCategories();
    this.navbarService.getNavbarItems();
  }

  addCategory() {
    this.touristPoint.categories.push(this.selectedCategory)
    this.categories = this.categories.filter(e => e.name != this.selectedCategory)
    if (this.categories.length != 0) this.selectedCategory = this.categories[0].name
  }

  deleteCategory(category: string) {
    if (this.categories.length == 0) this.selectedCategory = category
    this.touristPoint.categories = this.touristPoint.categories.filter(e => e != category)
    let categoryObj: Category = {name: category}
    this.categories.push(categoryObj)
  }

  getRegions() {
    this.regionService.getRegions().subscribe(d => {
      this.regions = d
      this.touristPoint.regionName = d[0].name
    }, error => {
      console.error(error)
      alert(error);
    });
  }

  getCategories() {
    this.categoryService.getCategories().subscribe(d => {
      this.categories = d
      this.selectedCategory = d[0].name
    }, error => {
      console.error(error);
      alert(error);
    });
  }

  createTouristPoint() {
    this.touristPointService.postCreateTouristPoint(this.touristPoint).subscribe(() => {
      this.saved = true;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }

  encodeImageFileAsURL(e) {
    let reader = new FileReader();
    reader.onloadend = () => this.touristPoint.image = reader.result.toString().replace('data:image/png;base64,', '').replace('data:image/jpeg;base64,', '')
    reader.readAsDataURL(e[0]);
  }
}