import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {Region} from "../models/region/Region";
import {catchError} from "rxjs/operators";
import {Login} from "../models/session/Login";

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private uri = environment.URI_BASE + "sessions";

  constructor(private httpClient: HttpClient) {
  }

  postLogin():Observable<Login[]>{
    return this.httpClient.post<Login[]>(this.uri).pipe(catchError(this.handleError))
  }

  private handleError(error: HttpErrorResponse){
    let message : string;

    if(error.error instanceof ErrorEvent){
      //Error de conexion del lado del cliente
      message = "Error: do it again";
    }else{
      //El backend respondio con status code de error
      //el body de la response debe de dar mas informacion
      if(error.status == 0){
        message = "The server is shutdown";
      }else{
        message = error.error.description;
      }
    }
    return throwError(message);
  }
}
