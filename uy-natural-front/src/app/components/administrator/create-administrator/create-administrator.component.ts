import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {AdministratorService} from "../../../services/administrator.service";
import {Administrator} from "../../../models/administrator/Administrator";

@Component({
  selector: 'app-create-administrator',
  templateUrl: './create-administrator.component.html',
  styleUrls: ['./create-administrator.component.css']
})
export class CreateAdministratorComponent implements OnInit {

  constructor(public navbarService: NavbarService, private administratorService: AdministratorService) {
  }

  public admin: Administrator = {
    name: "",
    email: "",
    password: ""
  }

  ngOnInit(): void {
  }

  saveAdmin() {
    this.administratorService.postCreateAdmin(this.admin).subscribe(() => {
    });
  }
}
