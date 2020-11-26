import {Booking} from "../booking/Booking";

export interface Lodging {
  "id"?: number,
  "name": string,
  "numberOfStars"?: number,
  "touristPointId": number,
  "address": string,
  "images": string[],
  "bookings"?: Booking[];
  "costPerNight": number,
  "description": string,
  "contactNumber": string,
  "descriptionForBookings": string,
  "maximumSize": number,
  "calculatedPrice"?: number,
  "reviewsCount"?: number
}
