import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Administrator} from "../models/administrator/Administrator";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AdministratorService {

  constructor(private httpClient: HttpClient) {
  }

  private uri: string = `${environment.URI_BASE}/administrators`

  postCreateAdmin(admin: Administrator): Observable<Administrator> {
    return this.httpClient.post<Administrator>(this.uri, {
      name: admin.name,
      email: admin.email,
      password: admin.password
    });
  }

  deleteAdmin(admin: Administrator): Observable<any> {
    return this.httpClient.delete(`${this.uri}/${admin.email}`);
  }

  updateAdmin(admin: Administrator): Observable<Administrator> {
    return this.httpClient.put<Administrator>(`${this.uri}/${admin.email}`, {
      name: admin.name,
      password: admin.password
    });
  }
}
