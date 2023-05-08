import { Component, OnInit } from '@angular/core';
import { Recruiter } from "../../recruiters/models/recruiter";
import { Router } from "@angular/router";
import { ProfileSettingsService } from "../services/profile-settings.service";

@Component({
  selector: 'app-recruiter-settings',
  templateUrl: './recruiter-settings.component.html',
  styleUrls: ['./recruiter-settings.component.scss']
})
export class RecruiterSettingsComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;
  public companyName: string | null = null;
  public phoneNumber: string | null = null;
  public biography: string | null = null;
  public location: string | null = null;
  public recruiterRequest!: Recruiter;

  constructor(private profileSettingsService: ProfileSettingsService,
              private router: Router) { }

  ngOnInit(): void {
    console.log("recruiter settings");
  }

  public handleClick(): void {
    this.recruiterRequest = {
      firstName: '',
      lastName: '',
      companyName: '',
      phoneNumber: '',
      biography: '',
      location: '',
      userGID: ''
    }

    this.recruiterRequest.firstName = this.firstName;
    this.recruiterRequest.lastName = this.lastName;
    this.recruiterRequest.companyName = this.companyName;
    this.recruiterRequest.phoneNumber = this.phoneNumber;
    this.recruiterRequest.biography = this.biography;
    this.recruiterRequest.location = this.location;
    this.recruiterRequest.userGID = localStorage.getItem("USER_GID");

    this.profileSettingsService.createRecruiter(this.recruiterRequest).subscribe((data) =>
    {
      localStorage.setItem("FIRSTNAME", data.firstName ?? "");
      localStorage.setItem("LASTNAME", data.lastName ?? "");
      localStorage.setItem("LOCATION", data.location ?? "");
      this.router.navigate(['/role-recruiter'])
    }, (error) => {
      console.log(error);
    })
  }
}
