import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {ImporterService} from "../../../services/importer.service";
import {Migration} from "../../../models/migration/Migration";

@Component({
  selector: 'app-migrate-lodgings',
  templateUrl: './migrate-lodgings.component.html',
  styleUrls: ['./migrate-lodgings.component.css']
})
export class MigrateLodgingsComponent implements OnInit {

  constructor(public navbarService: NavbarService, private importerService: ImporterService) {
  }

  importers: string[] = []

  migrationData: Migration = {
    path: "",
    importerName: ""
  }

  ngOnInit(): void {
    this.loadImporters()
  }

  loadImporters() {
    this.importerService.getAllImporters().subscribe(m => {
      this.importers = m
      this.migrationData.importerName = m[0]
    })
  }

  executeMigration() {
    this.importerService.postExecuteMigration(this.migrationData).subscribe(_ => {
    })
  }
}
