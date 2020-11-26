import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {Migration} from "../models/migration/Migration";
import {HandlerError} from "./handler-error/handler-error";
import {catchError} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ImporterService {

  constructor(private httpClient: HttpClient, private handlerError: HandlerError) {
  }

  private uri: string = `${environment.URI_BASE}/importers`

  getAllImporters(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.uri).pipe(catchError(this.handlerError.handleError));
  }

  postExecuteMigration(migration: Migration): Observable<any> {
    return this.httpClient.post(this.uri, {
      name: migration.importerName,
      filePath: migration.path
    }).pipe(catchError(this.handlerError.handleError));
  }
}
