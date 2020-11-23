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
    this.getTouristPoints()
  }

  getTouristPoints() {
    this.touristPointService.getTouristPoints().subscribe(d => {
      this.touristPoints = d;
      this.lodging.touristPointId = d[0].id
      this.touristPointName = d[0].name
    })
  }

  createLodging() {
    console.log(this.lodging)
    this.lodging.touristPointId = this.touristPoints.find(tp => tp.name == this.touristPointName).id
    this.lodgingService.postCreateLodging(this.lodging).subscribe(m => {
    })
  }
}
