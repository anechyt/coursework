import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import {AuthService} from "../services/auth.service";
import {RegisterRequest} from "../models/register-request";
import * as events from "events";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
  public email: string | null = null;
  public password: string | null = null;
  public role: string | null = null;
  public registerRequest!: RegisterRequest;

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit(): void {
  }

  public handleClick(): void {
    this.registerRequest = {
      email: '',
      password: '',
      role: ''
    }

    this.registerRequest.email = this.email;
    this.registerRequest.password = this.password;
    this.registerRequest.role = this.role;

    this.authService.register(this.registerRequest).subscribe(
      (data) => {
        if(data.accessToken != null && data.userGID != null){
          localStorage.setItem("ACCESS_TOKEN", data.accessToken);
          localStorage.setItem("USER_GID", data.userGID);
          localStorage.setItem("ROLE", data.role)

          this.authService.checkData(data.userGID, data.role);
        }
      }, (error) => {
        console.log(error.status);
      }
    )
  }
  public onItemChange(event: any): void {
    this.role = event.target.value;
  }
}

