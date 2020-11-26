import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {TouristPoint} from "../models/touristPoint/TouristPoint";
import {FilterTouristPoint} from "../models/touristPoint/FilterTouristPoint";
import {HandlerError} from "./handler-error/handler-error";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class TouristPointService {
  constructor(private httpClient: HttpClient,  private handlerError: HandlerError) {
  }

  private uri: string = `${environment.URI_BASE}/tourist-points`;

  getTouristPoints(): Observable<TouristPoint[]> {
    return this.httpClient.get<TouristPoint[]>(this.uri).pipe(catchError(this.handlerError.handleError));
  }

  postCreateTouristPoint(touristPoint: TouristPoint): Observable<TouristPoint> {
    return this.httpClient.post<TouristPoint>(this.uri, {
      name: touristPoint.name,
      image: touristPoint.image,
      description: touristPoint.description,
      regionName: touristPoint.regionName,
      categories: touristPoint.categories
    }).pipe(catchError(this.handlerError.handleError));
  }

  getTouristPointsFiltered(filterTouristPoint: FilterTouristPoint): Observable<TouristPoint[]> {
    return this.httpClient.get<TouristPoint[]>(`${this.uri}?region=${filterTouristPoint.regionName}&category=${filterTouristPoint.categoryName}`)
      .pipe(catchError(this.handlerError.handleError));
  }
}
