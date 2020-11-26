import {Tourist} from "./Tourist";
import {ReviewIn} from "../review/ReviewIn";

export interface BookingToCreate{
  "touristName": string,
  "touristSurname" : string,
  "touristEmail": string,
  "checkInDate": string,
  "checkOutDate": string,
  "numberOfAdults": number,
  "numberOfChildren" : number,
  "numberOfBabies": number,
  "numberOfRetired": number,
  "lodgingId": number
}
