import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {LodgingService} from "../../../services/lodging.service";

@Component({
  selector: 'app-delete-lodging',
  templateUrl: './delete-lodging.component.html',
  styleUrls: ['./delete-lodging.component.css']
})
export class DeleteLodgingComponent implements OnInit {

  constructor(public navbarService: NavbarService, private lodgingService: LodgingService) {
  }

  errorMessage :string
  saved = false

  ngOnInit(): void {
  }

  lodgingId: number = 0

  deleteLodging() {
    this.lodgingService.deleteLodging(this.lodgingId).subscribe(m => {
      this.saved = true;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }
}
