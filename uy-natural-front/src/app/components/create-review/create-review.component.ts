import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../services/navbar.service";
import {Review} from "../../models/review/Review";
import {BookingService} from "../../services/booking.service";

@Component({
  selector: 'app-create-review',
  templateUrl: './create-review.component.html',
  styleUrls: ['./create-review.component.css']
})
export class CreateReviewComponent implements OnInit {

  constructor(public navbarService: NavbarService, private bookingService: BookingService) {
  }

  errorMessage :string
  saved = false

  review: Review = {
    reviewPoints: 0,
    reviewText: "",
    bookingId: ""
  }

  ngOnInit(): void {
    this.navbarService.getNavbarItems();
  }

  createReview() {
    this.bookingService.putBookingReview(this.review).subscribe(m => {
      this.saved = true;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }
}
