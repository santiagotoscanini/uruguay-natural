import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../services/navbar.service";
import {BookingUpdateState} from "../../models/booking/BookingUpdateState";
import {BookingService} from "../../services/booking.service";

@Component({
  selector: 'app-edit-booking-state',
  templateUrl: './edit-booking-state.component.html',
  styleUrls: ['./edit-booking-state.component.css']
})
export class EditBookingStateComponent implements OnInit {

  constructor(public navbarService: NavbarService, private bookingService: BookingService) {
    this.getBookingStates()
  }

  bookingStates;
  errorMessage :string
  saved = false

  ngOnInit(): void {
    this.navbarService.getNavbarItems()
  }

  selectedState = ""

  bookingUpdateState: BookingUpdateState = {
    bookingId: "",
    state: 0,
    description: ""
  }

  getBookingStates() {
    this.bookingStates = this.bookingService.getBookingStates()
    this.selectedState = Object.keys(this.bookingStates)[0]
  }

  editBookingState() {
    this.bookingUpdateState.state = this.bookingStates[this.selectedState]
    this.bookingService.putUpdateBookingState(this.bookingUpdateState).subscribe(m => {
      this.saved = true;
      this.errorMessage = null;
      this.cleanFields();
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }

  private cleanFields() {
    this.bookingUpdateState.bookingId = "";
    this.bookingUpdateState.description = "";
  }
}
