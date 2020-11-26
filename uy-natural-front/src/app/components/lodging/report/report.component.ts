import {Component, OnInit} from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {Report} from "../../../models/report/Report";
import {Lodging} from "../../../models/lodging/Lodging";
import {LodgingService} from "../../../services/lodging.service";
import {TouristPoint} from "../../../models/touristPoint/TouristPoint";
import {TouristPointService} from "../../../services/tourist-point.service";

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {

  constructor(public navbarService: NavbarService, private lodgingService: LodgingService, private touristPointService: TouristPointService) {
  }

  ngOnInit(): void {
    this.getTouristPoints();
    this.navbarService.getNavbarItems();
  }

  touristPoints: TouristPoint[] = []
  lodgingsToShow: Lodging[] = []

  touristPointName: string = ""
  checkInDate = new Date()
  checkOutDate = new Date()

  reportFilter: Report = {
    touristPointId: 0,
    checkInDate: "",
    checkOutDate: ""
  }

  getTouristPoints() {
    this.touristPointService.getTouristPoints().subscribe(d => {
      this.touristPoints = d;
      this.reportFilter.touristPointId = d[0].id
      this.touristPointName = d[0].name
    })
  }

  applyReport() {
    this.reportFilter.touristPointId = this.touristPoints.find(tp => tp.name == this.touristPointName).id
    this.reportFilter.checkInDate = new Date(this.checkInDate).toISOString()
    this.reportFilter.checkOutDate = new Date(this.checkOutDate).toISOString()
    this.lodgingService.getReportFromLodgings(this.reportFilter).subscribe(d => {
      this.lodgingsToShow = d;
    }, error => {
      console.error(error);
      alert(error);
    });
  }
}
