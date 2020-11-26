import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {AdministratorService} from "../../../services/administrator.service";
import {Administrator} from "../../../models/administrator/Administrator";

@Component({
  selector: 'app-delete-administrator',
  templateUrl: './delete-administrator.component.html',
  styleUrls: ['./delete-administrator.component.css']
})
export class DeleteAdministratorComponent implements OnInit {

  constructor(public navbarService: NavbarService, private administratorService: AdministratorService) {
  }

  errorMessage :string
  saved = false

  public admin: Administrator = {
    name: "",
    email: "",
  }

  ngOnInit(): void {
    this.navbarService.getNavbarItems();
  }

  deleteAdmin() {
    this.administratorService.deleteAdmin(this.admin).subscribe(m => {
      this.saved = true;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }
}
