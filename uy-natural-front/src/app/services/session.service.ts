import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Token} from "../models/session/Token";
import {Login} from "../models/session/Login";

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  constructor(private httpClient: HttpClient) {
  }

  private uri: string = `${environment.URI_BASE}/sessions`;

  postLogin(login: Login): Observable<Token> {
    return this.httpClient.post<Token>(this.uri, {
      email: login.email,
      password: login.password
    });
  }

  postLogout(): Observable<object> {
    return this.httpClient.post(`${this.uri}/logout`, {
      token: this.getToken()
    });
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
