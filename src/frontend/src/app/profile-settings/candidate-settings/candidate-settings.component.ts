import { Component, OnInit } from '@angular/core';
import { ProfileSettingsService } from "../services/profile-settings.service";
import { Router } from "@angular/router";
import { Candidate } from "../../candidates/models/candidate";

@Component({
  selector: 'app-candidate-settings',
  templateUrl: './candidate-settings.component.html',
  styleUrls: ['./candidate-settings.component.scss']
})
export class CandidateSettingsComponent implements OnInit {
  public firstName: string | null = null;
  public lastName: string | null = null;
  public phoneNumber: string | null = null;
  public biography: string | null = null;
  public resume: string | null = null;
  public location: string | null = null;
  public candidateRequest!: Candidate;

  constructor(private profileSettingsService: ProfileSettingsService,
              private router: Router) { }

  ngOnInit(): void {
    console.log("candidate settings");
  }

  public handleClick(): void {
    this.candidateRequest = {
      firstName: '',
      lastName: '',
      phoneNumber: '',
      biography: '',
      resume: '',
      location: '',
      userGID: ''
    }

    this.candidateRequest.firstName = this.firstName;
    this.candidateRequest.lastName = this.lastName;
    this.candidateRequest.phoneNumber = this.phoneNumber;
    this.candidateRequest.biography = this.biography;
    this.candidateRequest.resume = this.resume;
    this.candidateRequest.location = this.location;
    this.candidateRequest.userGID = localStorage.getItem("USER_GID");

    this.profileSettingsService.createCandidate(this.candidateRequest).subscribe((data) =>
    {
      localStorage.setItem("FIRSTNAME", data.firstName ?? "");
      localStorage.setItem("LASTNAME", data.lastName ?? "");
      localStorage.setItem("LOCATION", data.location ?? "");
      this.router.navigate(['/role-candidate'])
    }, (error) => {
      console.log(error);
    })
  }
}
