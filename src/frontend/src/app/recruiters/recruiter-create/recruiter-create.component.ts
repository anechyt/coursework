import {AfterViewInit, Component, OnInit} from '@angular/core';
import { RecruiterService } from "../services/recruiter.service";
import { Recruiter } from "../models/recruiter";
import { Router } from "@angular/router";

@Component({
  selector: 'app-recruiter-create',
  templateUrl: './recruiter-create.component.html',
  styleUrls: ['./recruiter-create.component.scss']
})
export class RecruiterCreateComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;
  public companyName: string | null = null;
  public phoneNumber: string | null = null;
  public biography: string | null = null;

  public location: string | null = null;
  public isShowContent: boolean = false;
  public recruiterRequest!: Recruiter;

  constructor(private recruiterService: RecruiterService,
              private router: Router) { }

  ngOnInit(): void {
    const userGID = localStorage.getItem("USER_GID");
    this.recruiterService.getRecruiterByUserGID(userGID ?? "").subscribe((data) => {
      if(data != null) {
        localStorage.setItem("FIRSTNAME", data.firstName ?? "");
        localStorage.setItem("LASTNAME", data.lastName ?? "");
        localStorage.setItem("LOCATION", data.location ?? "");
        this.router.navigate(['home'])
      } else {
        this.isShowContent = true;
      }
    }, (error) => {
      console.log(error)
    });
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

    this.recruiterService.createRecruiter(this.recruiterRequest).subscribe((data) =>
    {
      localStorage.setItem("FIRSTNAME", data.firstName ?? "");
      localStorage.setItem("LASTNAME", data.lastName ?? "");
      localStorage.setItem("LOCATION", data.location ?? "");
      this.router.navigate(['home'])
    }, (error) => {
      console.log(error);
      })
  }
}
