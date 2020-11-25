import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {Region} from "../../../models/region/Region";
import {Category} from "../../../models/category/Category";
import {RegionService} from "../../../services/region.service";
import {FilterTouristPoint} from "../../../models/touristPoint/FilterTouristPoint";
import {CategoryService} from "../../../services/category.service";
import {TouristPoint} from "../../../models/touristPoint/TouristPoint";
import {TouristPointService} from "../../../services/tourist-point.service";
import {Router} from "@angular/router";
import {DomSanitizer} from "@angular/platform-browser";

@Component({
  selector: 'app-search-tourist-point',
  templateUrl: './search-tourist-point.component.html',
  styleUrls: ['./search-tourist-point.component.css']
})
export class SearchTouristPointComponent implements OnInit {

  constructor(private router: Router, public navbarService: NavbarService, private regionService: RegionService, private categoryService: CategoryService, private touristPointService: TouristPointService, public sanitizer: DomSanitizer) {
  }

  ngOnInit(): void {
    this.getRegions()
    this.getCategories()
  }

  regionsToShow: Region[]
  categoriesToShow: Category[]

  touristPointsToShow: TouristPoint[] = []

  filterTouristPoint: FilterTouristPoint = {
    regionName: "",
    categoryName: ""
  }

  getRegions() {
    this.regionService.getRegions().subscribe(m => {
      this.regionsToShow = m
      this.filterTouristPoint.regionName = m[0].name
    }, error => {
      console.error(error);
      alert(error);
    });
  }

  getCategories() {
    this.categoryService.getCategories().subscribe(m => {
      this.categoriesToShow = m
      this.filterTouristPoint.categoryName = m[0].name
    }, error => {
      console.error(error);
      alert(error);
    });
  }

  alreadySearch = false

  searchTouristPoints() {
    this.touristPointService.getTouristPointsFiltered(this.filterTouristPoint).subscribe(m => {
      this.touristPointsToShow = m;
      this.alreadySearch = true;
    }, error => {
      console.error(error)
      alert(error);
    });
  }

  goToTouristPointPage(touristPoint : TouristPoint) {
    this.router.navigate([`booking/search-lodging/${touristPoint.id}`]);
    sessionStorage.setItem('tourist-point-name', touristPoint.name)
  }
}
