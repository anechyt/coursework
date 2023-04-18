import { Component, OnInit } from '@angular/core';
import { AuthService } from "../services/auth.service";
import { LoginRequest } from "../models/login-request";
import { Router } from "@angular/router";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
  public email: string | null = null;
  public password: string | null = null;
  public loginRequest!: LoginRequest;
  constructor(private authService: AuthService,
              private router: Router) { }
  ngOnInit(): void {
  }
  public handleClick(): void {
    this.loginRequest = {
      email: '',
      password: ''
    }

    this.loginRequest.email = this.email;
    this.loginRequest.password = this.password;


    this.authService.login(this.loginRequest).subscribe(
      (data) => {
        localStorage.setItem("ACCESS_TOKEN", data.accessToken);
        localStorage.setItem("USER_GID", data.userGID);
        localStorage.setItem("ROLE", data.role);
        if(data.role === 'candidate') {
          this.router.navigate(['/role-candidate'])
        }
        else {
          this.router.navigate(['/role-recruiter'])
        }
      }, (error) => {
        console.log(error.status);
      }
    )
  }
}
