import { Component, OnInit } from '@angular/core';
import {NavbarService} from "../../services/navbar.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  constructor(public navbarService: NavbarService) { }

  ngOnInit(): void {
  }

}
