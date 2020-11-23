import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Lodging} from "../models/lodging/Lodging";
import {Observable} from "rxjs";
import {LodgingUpdateCapacity} from "../models/lodging/LodgingUpdateCapacity";
import {Report} from "../models/report/Report";

@Injectable({
  providedIn: 'root'
})
export class LodgingService {

  constructor(private httpClient: HttpClient) {
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
    })
  }

  putUpdateLodgingCapacity(lodgingUpdateCapacity: LodgingUpdateCapacity): Observable<any> {
    return this.httpClient.put<Observable<any>>(`${this.uri}/${lodgingUpdateCapacity.lodgingId}`, {actualCapacity: lodgingUpdateCapacity.newCapacity})
  }

  deleteLodging(lodgingId: number) {
    return this.httpClient.delete<Observable<any>>(`${this.uri}/${lodgingId}`).subscribe(() => {
    })
  }

  getReportFromLodgings(report: Report): Observable<Lodging[]> {
    let reportURI = `${this.uri}/reports?TouristPointId=${report.touristPointId}&CheckInDate=${report.checkInDate}&CheckOutDate=${report.checkOutDate}`
    console.log(reportURI)
    return this.httpClient.get<Lodging[]>(reportURI)
  }
}
