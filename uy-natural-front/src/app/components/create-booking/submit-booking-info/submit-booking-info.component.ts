import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {NavbarService} from "../../../services/navbar.service";
import {LodgingFilter} from "../../../models/lodging/LodgingFilter";
import {BookingToCreate} from "../../../models/booking/BookingToCreate";
import {BookingService} from "../../../services/booking.service";
import {BookingResponse} from "../../../models/booking/BookingResponse";

@Component({
  selector: 'app-submit-booking-info',
  templateUrl: './submit-booking-info.component.html',
  styleUrls: ['./submit-booking-info.component.css']
})
export class SubmitBookingInfoComponent implements OnInit {

  constructor(private router: Router, public navbarService: NavbarService, private bookingService : BookingService) { }

  ngOnInit(): void {
    this.booking.lodgingId = (JSON.parse(sessionStorage.getItem('lodging'))).id;
    this.setBookingInfo(JSON.parse(sessionStorage.getItem('lodging-filtered')))
  }

  private setBookingInfo(lodgingFilter: LodgingFilter){
    this.booking.checkInDate = lodgingFilter.checkInDate;
    this.booking.checkOutDate = lodgingFilter.checkOutDate;
    this.booking.numberOfAdults = lodgingFilter.numberOfAdults;
    this.booking.numberOfChildren = lodgingFilter.numberOfChildren;
    this.booking.numberOfBabies = lodgingFilter.numberOfBabies;
    this.booking.numberOfRetired = lodgingFilter.numberOfRetired;
  }

  booking : BookingToCreate = {
    touristName: "",
    touristSurname: "",
    touristEmail: "",
    checkInDate: "",
    checkOutDate: "",
    numberOfAdults: 0,
    numberOfChildren : 0,
    numberOfBabies: 0,
    numberOfRetired: 0,
    lodgingId: 0
  }

  createBooking(){
    this.bookingService.postBooking(this.booking).subscribe(b => {
      sessionStorage.setItem('booking-response', JSON.stringify(b));
      this.router.navigate([`booking/confirmation`]);
    })
  }
}
