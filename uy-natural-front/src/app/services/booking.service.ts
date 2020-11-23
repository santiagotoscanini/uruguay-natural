import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BookingUpdateState} from "../models/booking/BookingUpdateState";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {Review} from "../models/review/Review";

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private httpClient: HttpClient) {
  }

  private uri = environment.URI_BASE + "/bookings";

  PutUpdateBookingState(bookingUpdateState: BookingUpdateState): Observable<any> {
    return this.httpClient.put(`${this.uri}/${bookingUpdateState.bookingId}`, {
      state: bookingUpdateState.state,
      description: bookingUpdateState.description
    })
  }

  getBookingStates(): { [key: string]: number } {
    return {
      "Created": 0,
      "Pending of Pay": 1,
      "Accepted": 2,
      "Rejected": 3,
      "Expired": 4,
    }
  }

  getBookingStatusById(bookingId: string): Observable<BookingUpdateState> {
    return this.httpClient.get<BookingUpdateState>(`${this.uri}/${bookingId}`);
  }

  putBookingReview(review: Review): Observable<any> {
    return this.httpClient.put(`${this.uri}/${review.bookingId}/reviews`, {
      reviewText: review.reviewText,
      reviewPoinrs: review.reviewPoints
    })
  }
}
