import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {environment} from "../../environments/environment";
import {Observable, throwError} from "rxjs";
import {catchError} from "rxjs/operators";
import {Category} from "../models/category/Category";
import {HandlerError} from "./handler-error/handler-error";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private uri = environment.URI_BASE + "/categories";

  constructor(private httpClient: HttpClient, private handlerError: HandlerError) { }

  getCategories():Observable<Category[]>{
    return this.httpClient.get<Category[]>(this.uri).pipe(catchError(this.handlerError.handleError));
  }
}
