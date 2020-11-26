import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Lodging} from "../models/lodging/Lodging";
import {Observable} from "rxjs";
import {LodgingUpdateCapacity} from "../models/lodging/LodgingUpdateCapacity";
import {Report} from "../models/report/Report";
import {LodgingFilter} from "../models/lodging/LodgingFilter";
import {HandlerError} from "./handler-error/handler-error";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class LodgingService {

  constructor(private httpClient: HttpClient, private handlerError: HandlerError) {
  }

  private uri: string = `${environment.URI_BASE}/lodgings`;

  postCreateLodging(lodging: Lodging): Observable<Lodging> {
    return this.httpClient.post<Lodging>(this.uri, {
      name: lodging.name,
      touristPointId: lodging.touristPointId,
      address: lodging.address,
      images: lodging.images,
      costPerNight: lodging.costPerNight,
      description: lodging.description,
      contactNumber: lodging.contactNumber,
      descriptionForBookings: lodging.descriptionForBookings,
      maximumSize: lodging.maximumSize,
    }).pipe(catchError(this.handlerError.handleError));
  }

  putUpdateLodgingCapacity(lodgingUpdateCapacity: LodgingUpdateCapacity): Observable<any> {
    return this.httpClient.put<Observable<any>>(`${this.uri}/${lodgingUpdateCapacity.lodgingId}`, {actualCapacity: lodgingUpdateCapacity.newCapacity})
      .pipe(catchError(this.handlerError.handleError));
  }

  deleteLodging(lodgingId: number): Observable<any> {
    return this.httpClient.delete<Observable<any>>(`${this.uri}/${lodgingId}`).pipe(catchError(this.handlerError.handleError));
  }

  getReportFromLodgings(report: Report): Observable<Lodging[]> {
    let reportURI = `${this.uri}/reports?TouristPointId=${report.touristPointId}&CheckInDate=${report.checkInDate}&CheckOutDate=${report.checkOutDate}`
    return this.httpClient.get<Lodging[]>(reportURI).pipe(catchError(this.handlerError.handleError));
  }

  getLodgingsFiltered(lodgingFilter: LodgingFilter): Observable<Lodging[]> {
    let finalURL = `${this.uri}?touristPointId=${lodgingFilter.touristPointId}&checkInDate=${lodgingFilter.checkInDate}&checkOutDate=${lodgingFilter.checkOutDate}&numberOfAdults=${lodgingFilter.numberOfAdults}&numberOfChildren=${lodgingFilter.numberOfChildren}&numberOfBabies=${lodgingFilter.numberOfBabies}&numberOfRetired=${lodgingFilter.numberOfRetired}`;
    return this.httpClient.get<Lodging[]>(finalURL).pipe(catchError(this.handlerError.handleError));
  }
}
