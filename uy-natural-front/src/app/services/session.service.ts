import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Token} from "../models/session/Token";
import {Login} from "../models/session/Login";
import {catchError} from "rxjs/operators";
import {HandlerError} from "./handler-error/handler-error";

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  constructor(private httpClient: HttpClient, private handlerError: HandlerError) {
  }

  private uri: string = `${environment.URI_BASE}/sessions`;

  postLogin(login: Login): Observable<Token> {
    return this.httpClient.post<Token>(this.uri, {
      email: login.email,
      password: login.password
    }).pipe(catchError(this.handlerError.handleError));
  }

  postLogout(): Observable<object> {
    return this.httpClient.post(`${this.uri}/logout`, {
      token: this.getToken()
    }).pipe(catchError(this.handlerError.handleError));
  }

  removeToken(): void {
    localStorage.removeItem('userToken')
  }

  isUserLogged(): boolean {
    return this.getToken() != null;
  }

  saveToken(token: Token): void {
    localStorage.setItem('userToken', token.token);
  }

  getToken(): string {
    return localStorage.getItem('userToken');
  }
}
