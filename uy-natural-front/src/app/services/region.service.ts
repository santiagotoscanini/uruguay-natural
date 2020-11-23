import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from "../../environments/environment";
import {Region} from '../models/region/Region';
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private uri = environment.URI_BASE + "/regions";

  constructor(private httpClient: HttpClient) {
  }

  getRegions(): Observable<Region[]> {
    return this.httpClient.get<Region[]>(this.uri)
  }
}
