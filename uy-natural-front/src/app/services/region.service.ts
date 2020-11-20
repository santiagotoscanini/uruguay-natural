import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {environment} from "../../environments/environment";
import {Region} from '../models/Region';
import {Observable, throwError} from "rxjs";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  private uri = environment.URI_BASE + "regions";

  constructor(private httpClient: HttpClient) {

  }

  getRegions():Observable<Region[]>{
    return this.httpClient.get<Region[]>(this.uri).pipe(catchError(this.handleError))
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
