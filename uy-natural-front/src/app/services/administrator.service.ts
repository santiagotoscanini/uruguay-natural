import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Administrator} from "../models/administrator/Administrator";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {HandlerError} from "./handler-error/handler-error";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AdministratorService {

  constructor(private httpClient: HttpClient, private handlerError: HandlerError) {
  }

  private uri: string = `${environment.URI_BASE}/administrators`

  postCreateAdmin(admin: Administrator): Observable<Administrator> {
    return this.httpClient.post<Administrator>(this.uri, {
      name: admin.name,
      email: admin.email,
      password: admin.password
    }).pipe(catchError(this.handlerError.handleError));
  }

  deleteAdmin(admin: Administrator): Observable<any> {
    return this.httpClient.delete(`${this.uri}/${admin.email}`).pipe(catchError(this.handlerError.handleError));
  }

  updateAdmin(admin: Administrator): Observable<Administrator> {
    return this.httpClient.put<Administrator>(`${this.uri}/${admin.email}`, {
      name: admin.name,
      password: admin.password
    }).pipe(catchError(this.handlerError.handleError));
  }
}
