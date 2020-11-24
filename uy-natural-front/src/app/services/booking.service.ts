import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BookingUpdateState} from "../models/booking/BookingUpdateState";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {Review} from "../models/review/Review";
import {BookingToCreate} from "../models/booking/BookingToCreate";
import {BookingResponse} from "../models/booking/BookingResponse";

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
      reviewPoints: review.reviewPoints
    })
  }

  postBooking(booking: BookingToCreate): Observable<BookingResponse>{
    return this.httpClient.post<BookingResponse>(this.uri, {
      touristName:booking.touristName,
      touristSurname :booking.touristSurname,
      touristEmail:booking.touristEmail,
      checkInDate:booking.checkInDate,
      checkOutDate:booking.checkOutDate,
      numberOfAdults:booking.numberOfAdults,
      numberOfChildren :booking.numberOfChildren,
      numberOfBabies:booking.numberOfBabies,
      numberOfRetired:booking.numberOfRetired,
      lodgingId:booking.lodgingId
    })
  }
}
