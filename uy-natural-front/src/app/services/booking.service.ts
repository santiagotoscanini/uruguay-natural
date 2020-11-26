import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BookingUpdateState} from "../models/booking/BookingUpdateState";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {Review} from "../models/review/Review";
import {BookingToCreate} from "../models/booking/BookingToCreate";
import {BookingResponse} from "../models/booking/BookingResponse";
import {HandlerError} from "./handler-error/handler-error";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private httpClient: HttpClient, private handlerError: HandlerError) {
  }

  private uri = environment.URI_BASE + "/bookings";

  putUpdateBookingState(bookingUpdateState: BookingUpdateState): Observable<any> {
    return this.httpClient.put(`${this.uri}/${bookingUpdateState.bookingId}`, {
      state: bookingUpdateState.state,
      description: bookingUpdateState.description
    }).pipe(catchError(this.handlerError.handleError));
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
    return this.httpClient.get<BookingUpdateState>(`${this.uri}/${bookingId}`).pipe(catchError(this.handlerError.handleError));
  }

  putBookingReview(review: Review): Observable<any> {
    return this.httpClient.put(`${this.uri}/${review.bookingId}/reviews`, {
      reviewText: review.reviewText,
      reviewPoints: review.reviewPoints
    }).pipe(catchError(this.handlerError.handleError));
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
    }).pipe(catchError(this.handlerError.handleError));
  }
}
