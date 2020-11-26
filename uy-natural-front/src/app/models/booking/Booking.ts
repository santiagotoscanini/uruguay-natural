import {Tourist} from "./Tourist";
import {ReviewIn} from "../review/ReviewIn";

export interface Booking{
  "tourist": Tourist,
  "code" : string,
  "state": number,
  "description": string,
  "checkInDate" : string,
  "checkoutDate": string,
  "totalNumberOfGuests" : number,
  "touristReview" : ReviewIn,
}
