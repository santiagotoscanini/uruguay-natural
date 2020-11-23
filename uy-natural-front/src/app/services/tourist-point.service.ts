import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {TouristPoint} from "../models/touristPoint/TouristPoint";

@Injectable({
  providedIn: 'root'
})
export class TouristPointService {
  constructor(private httpClient: HttpClient) {
  }

  private uri: string = `${environment.URI_BASE}/tourist-points`;

  getTouristPoints(): Observable<TouristPoint[]> {
    return this.httpClient.get<TouristPoint[]>(this.uri)
  }

  postCreateTouristPoint(touristPoint: TouristPoint): Observable<TouristPoint> {
    return this.httpClient.post<TouristPoint>(this.uri, {
      name: touristPoint.name,
      image: touristPoint.image,
      description: touristPoint.description,
      regionName: touristPoint.regionName,
      categories: touristPoint.categories
    })
  }
}
