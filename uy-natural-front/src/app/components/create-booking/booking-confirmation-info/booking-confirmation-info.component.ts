import { Component, OnInit } from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {BookingResponse} from "../../../models/booking/BookingResponse";

@Component({
  selector: 'app-booking-confirmation-info',
  templateUrl: './booking-confirmation-info.component.html',
  styleUrls: ['./booking-confirmation-info.component.css']
})
export class BookingConfirmationInfoComponent implements OnInit {

  constructor(public navbarService: NavbarService) { }

  ngOnInit(): void {
    this.bookingRespnse = (JSON.parse(sessionStorage.getItem('booking-response')));
  }

  bookingRespnse: BookingResponse
}
