import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {AdministratorService} from "../../../services/administrator.service";
import {Administrator} from "../../../models/administrator/Administrator";

@Component({
  selector: 'app-edit-administrator',
  templateUrl: './edit-administrator.component.html',
  styleUrls: ['./edit-administrator.component.css']
})
export class EditAdministratorComponent implements OnInit {

  constructor(public navbarService: NavbarService, private administratorService: AdministratorService) {
  }

  public admin: Administrator = {
    name: "",
    email: "",
    password: ""
  }

  ngOnInit(): void {
  }

  updateAdmin() {
    this.administratorService.updateAdmin(this.admin).subscribe(_ => {
    });
  }
}
