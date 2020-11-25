import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {TouristPointService} from "../../../services/tourist-point.service";
import {TouristPoint} from "../../../models/touristPoint/TouristPoint";
import {LodgingService} from "../../../services/lodging.service";
import {Lodging} from "../../../models/lodging/Lodging";

@Component({
  selector: 'app-create-lodging',
  templateUrl: './create-lodging.component.html',
  styleUrls: ['./create-lodging.component.css']
})
export class CreateLodgingComponent implements OnInit {

  constructor(public navbarService: NavbarService, private touristPointService: TouristPointService, private lodgingService: LodgingService) {
  }

  touristPointName: string = ""
  errorMessage :string
  saved = false

  lodging: Lodging = {
    name: "",
    touristPointId: -1,
    address: "",
    images: [""],
    costPerNight: 0,
    contactNumber: "",
    maximumSize: 0,
    descriptionForBookings: "",
    description: "",
  }

  touristPoints: TouristPoint[]

  ngOnInit(): void {
    this.getTouristPoints();
  }

  getTouristPoints() {
    this.touristPointService.getTouristPoints().subscribe(d => {
      this.touristPoints = d;
      this.lodging.touristPointId = d[0].id
      this.touristPointName = d[0].name
    }, error => {
      console.error(error);
      alert(error);
    });
  }

  createLodging() {
    this.lodging.touristPointId = this.touristPoints.find(tp => tp.name == this.touristPointName).id
    this.lodgingService.postCreateLodging(this.lodging).subscribe(m => {
      this.saved = true;
      this.errorMessage = null;
    }, error => {
      console.error(error);
      this.errorMessage = error;
      this.saved = false;
    });
  }

  encodeImageFileAsURL(event) {
    let files = [...event.target.files];
    let images = Promise.all(files.map(this.readAsDataURL)).then((i: string[]) => this.lodging.images = i)
  }

  readAsDataURL(file) {
    return new Promise((resolve, _) => {
      let fileReader = new FileReader();
      fileReader.onload = () => resolve(fileReader.result.toString().replace('data:image/png;base64,', '').replace('data:image/jpeg;base64,', ''))
      fileReader.readAsDataURL(file);
    })
  }

}
