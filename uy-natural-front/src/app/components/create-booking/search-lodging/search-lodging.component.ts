import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {NavbarService} from "../../../services/navbar.service";
import {Lodging} from "../../../models/lodging/Lodging";
import {LodgingService} from "../../../services/lodging.service";
import {LodgingFilter} from "../../../models/lodging/LodgingFilter";

@Component({
  selector: 'app-search-lodging',
  templateUrl: './search-lodging.component.html',
  styleUrls: ['./search-lodging.component.css']
})
export class SearchLodgingComponent implements OnInit {

  constructor(private router: Router, public navbarService: NavbarService, private activatedRoute: ActivatedRoute, private lodgingService: LodgingService) {
  }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => this.lodgingFilter.touristPointId = parseInt(params.get('touristPointId')))
    console.log(this.lodgingFilter.touristPointId)
  }

  checkInDate = new Date()
  checkOutDate = new Date()

  lodgingsToShow: Lodging[] = []

  lodgingFilter: LodgingFilter = {
    touristPointId: -1,
    checkInDate: "",
    checkOutDate: "",
    numberOfAdults: 0,
    numberOfBabies: 0,
    numberOfChildren: 0,
    numberOfRetired: 0,
  }

  filterLodgings() {
    this.lodgingFilter.checkInDate = new Date(this.checkInDate).toISOString()
    this.lodgingFilter.checkOutDate = new Date(this.checkOutDate).toISOString()
    this.lodgingService.getLodgingsFiltered(this.lodgingFilter).subscribe(m => {
      this.lodgingsToShow = m
      console.log(m)
    })
  }

  goToLodging(lodging : Lodging) {
    sessionStorage.setItem('lodging-filtered', JSON.stringify(this.lodgingFilter));
    sessionStorage.setItem('lodging', JSON.stringify(lodging));
    this.router.navigate([`booking/lodging-info`]);
  }
}
