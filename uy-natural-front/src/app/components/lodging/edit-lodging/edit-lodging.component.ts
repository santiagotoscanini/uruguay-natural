import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {LodgingService} from "../../../services/lodging.service";
import {LodgingUpdateCapacity} from "../../../models/lodging/LodgingUpdateCapacity";

@Component({
  selector: 'app-edit-lodging',
  templateUrl: './edit-lodging.component.html',
  styleUrls: ['./edit-lodging.component.css']
})
export class EditLodgingComponent implements OnInit {

  constructor(public navbarService: NavbarService, private lodgingService: LodgingService) {
  }

  errorMessage :string
  saved = false

  ngOnInit(): void {
    this.navbarService.getNavbarItems();
  }

  lodgingUpdateCapacity: LodgingUpdateCapacity = {
    lodgingId: 0,
    newCapacity: 0
  }

  editLodgingCapacity() {
    this.lodgingService.putUpdateLodgingCapacity(this.lodgingUpdateCapacity).subscribe(()=>{
      this.saved = true;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }
}