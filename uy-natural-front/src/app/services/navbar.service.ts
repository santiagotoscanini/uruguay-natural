import {Injectable} from '@angular/core';
import {RouteItem} from "../models/routing/RouteItem";
import {SessionService} from "./session.service";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  constructor(private sessionService: SessionService, private router: Router) {
  }

  navbars: RouteItem[][] = [
    // unlogged user
    [
      {
        path: "booking/search-tourist-point",
        child: [],
        class: "nav-link",
        text: "Search"
      },
      {
        path: "",
        child: [
          {
            path: "booking/review",
            child: [],
            class: "",
            text: "Create Review"
          },
          {
            path: "booking/check-status",
            child: [],
            class: "",
            text: "Check Booking"
          }
        ],
        class: "bg-info",
        text: "Booking"
      },
      {
        path: "login",
        child: [],
        class: "nav-link",
        text: "Login"
      }
    ],

    // admin user
    [
      {
        path: "",
        child: [
          {
            path: "booking/edit-state",
            child: [],
            class: "",
            text: "Edit Booking"
          },
        ],
        class: "bg-info",
        text: "Bookings"
      },
      {
        path: "tourist-point/create",
        child: [],
        class: "nav-link",
        text: "Tourist points"
      },
      {
        path: "",
        child: [
          {
            path: "lodging/create",
            child: [],
            class: "",
            text: "Create new Lodging"
          },
          {
            path: "lodging/edit",
            child: [],
            class: "",
            text: "Edit Lodging"
          },
          {
            path: "lodging/delete",
            child: [],
            class: "",
            text: "Delete Lodging"
          },
          {
            path: "lodgings/migration",
            child: [],
            class: "",
            text: "Migrate Lodgings"
          },
          {
            path: "report",
            child: [],
            class: "",
            text: "Report"
          },
        ],
        class: "bg-info mr-2",
        text: "Lodgings"
      },
      {
        path: "",
        child: [
          {
            path: "administrator/create",
            child: [],
            class: "",
            text: "Create new administrator"
          },
          {
            path: "administrator/delete",
            child: [],
            class: "",
            text: "Delete administrator"
          },
          {
            path: "administrator/edit",
            child: [],
            class: "",
            text: "Edit administrator"
          }
        ],
        class: "bg-info mr-2",
        text: "Admins"
      },
      {
        path: "",
        child: [],
        class: "btn btn-danger",
        text: "Logout",
        method: () => {
          this.sessionService.postLogout().subscribe(() => {
            this.sessionService.removeToken();
            this.router.navigate(['home'])
          }, error => {
            console.error(error)
            alert(error)
          })
        }
      },
    ]
  ];

  getNavbarItems(): RouteItem[] {
    if (this.sessionService.isUserLogged()) {
      return this.navbars[1];
    } else {
      return this.navbars[0];
    }
  }
}
