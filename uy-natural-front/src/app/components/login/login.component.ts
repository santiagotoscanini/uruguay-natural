import {Component, OnInit} from '@angular/core';
import {SessionService} from "../../services/session.service";
import {Router} from "@angular/router";
import {NavbarService} from "../../services/navbar.service";
import {Login} from "../../models/session/Login";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private sessionService: SessionService, private router: Router, public navbarService: NavbarService) {
  }

  login: Login = {
    email: "",
    password: ""
  }

  ngOnInit(): void {
  }

  errorMessage : string

  onLogin() {
    return this.sessionService.postLogin(this.login).subscribe(data => {
      this.sessionService.saveToken(data);
      this.router.navigate(['/home']);
    }, error => {
      console.error(error)
      this.errorMessage = error
    });
  }
}
