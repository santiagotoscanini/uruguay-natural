import { Component, OnInit } from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {LodgingFilter} from "../../../models/lodging/LodgingFilter";
import {Lodging} from "../../../models/lodging/Lodging";
import {Router} from "@angular/router";

@Component({
  selector: 'app-lodging-info',
  templateUrl: './lodging-info.component.html',
  styleUrls: ['./lodging-info.component.css']
})
export class LodgingInfoComponent implements OnInit {

  constructor(private router: Router, public navbarService: NavbarService) { }

  ngOnInit(): void {
    this.lodging = JSON.parse(sessionStorage.getItem('lodging'));
    this.lodgignFiltered = JSON.parse(sessionStorage.getItem('lodging-filtered'));
    this.touristPointName = sessionStorage.getItem('tourist-point-name');
  }

  touristPointName = ""

  lodging: Lodging = {
    id : -1,
    name : "",
    numberOfStars : 0,
    touristPointId : -1,
    address : "",
    images : [""],
    bookings : null,
    costPerNight : 0,
    description : "",
    contactNumber : "",
    descriptionForBookings : "",
    maximumSize : 0,
    calculatedPrice : 0,
    reviewsCount : 0
  }

  lodgignFiltered : LodgingFilter = {
    touristPointId: -1,
    checkInDate: "",
    checkOutDate: "",
    numberOfAdults: 0,
    numberOfBabies: 0,
    numberOfChildren: 0,
    numberOfRetired: 0,
  }

  goToBooking() {
    this.router.navigate([`booking/submit-info`]);
  }
}
