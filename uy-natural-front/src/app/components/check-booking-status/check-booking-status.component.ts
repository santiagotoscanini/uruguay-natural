import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../services/navbar.service";
import {BookingService} from "../../services/booking.service";
import {BookingUpdateState} from "../../models/booking/BookingUpdateState";

@Component({
  selector: 'app-check-booking-status',
  templateUrl: './check-booking-status.component.html',
  styleUrls: ['./check-booking-status.component.css']
})
export class CheckBookingStatusComponent implements OnInit {

  constructor(public navbarService: NavbarService, private bookingService: BookingService) {
  }

  bookingStatus: BookingUpdateState
  bookingId: string = ""
  errorMessage :string

  ngOnInit(): void {
  }

  getBookingString(status: number) {
    let dict = this.bookingService.getBookingStates();
    return Object.keys(dict).find(key => dict[key] == status)
  }

  checkBookingStatus() {
    this.bookingService.getBookingStatusById(this.bookingId).subscribe(m => {
      this.bookingStatus = m;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.bookingStatus = null;
    });
  }
}
