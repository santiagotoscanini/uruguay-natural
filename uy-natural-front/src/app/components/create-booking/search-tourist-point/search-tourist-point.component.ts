import { Component, OnInit } from '@angular/core';
import {NavbarService} from "../../../services/navbar.service";
import {Region} from "../../../models/region/Region";

@Component({
  selector: 'app-search-tourist-point',
  templateUrl: './search-tourist-point.component.html',
  styleUrls: ['./search-tourist-point.component.css']
})
export class SearchTouristPointComponent implements OnInit {

  constructor(public navbarService: NavbarService) { }

  regionsToShow: Region[]
  catego
  ngOnInit(): void {
  }

}
