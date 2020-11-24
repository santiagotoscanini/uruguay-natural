export interface Lodging {
  "id"?: number,
  "name": string,
  "numberOfStars"?: number,
  "touristPointId": number,
  "address": string,
  "images": string[],
  "bookings"?: any[];
  "costPerNight": number,
  "description": string,
  "contactNumber": string,
  "descriptionForBookings": string,
  "maximumSize": number,
  "calculatedPrice"?: number,
  "reviewsCount"?: number
}
