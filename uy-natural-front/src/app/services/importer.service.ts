import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {Migration} from "../models/migration/Migration";

@Injectable({
  providedIn: 'root'
})
export class ImporterService {

  constructor(private httpClient: HttpClient) {
  }

  private uri: string = `${environment.URI_BASE}/importers`

  getAllImporters(): Observable<string[]> {
    return this.httpClient.get<string[]>(this.uri)
  }

  postExecuteMigration(migration: Migration): Observable<any> {
    return this.httpClient.post(this.uri, {
      name: migration.importerName,
      filePath: migration.path
    })
  }
}
