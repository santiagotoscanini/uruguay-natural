import {Component, Input, OnInit} from '@angular/core';
import {RouteItem} from "../../models/routing/RouteItem";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html'
})
export class NavbarComponent implements OnInit {
  @Input() treeOfItems: RouteItem[]

  constructor() {
  }

  ngOnInit(): void {
  }
}
