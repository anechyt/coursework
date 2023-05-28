import { Component, OnInit } from '@angular/core';
import { ProfileSettingsService } from "../services/profile-settings.service";
import { Router } from "@angular/router";
import {CandidatesResponse} from "../../candidates/models/candidates-response";
import { Skill } from "../../candidates/models/skill";

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
  public skill: string = '';
  public skills: Array<Skill> = [];
  public candidateRequest!: CandidatesResponse;

  constructor(private profileSettingsService: ProfileSettingsService,
              private router: Router) { }

  ngOnInit(): void {
  }

  public handleClick(): void {
    this.candidateRequest = {
      firstName: '',
      lastName: '',
      phoneNumber: '',
      biography: '',
      resume: '',
      location: '',
      skills: [],
      userGID: ''
    }

    this.candidateRequest.firstName = this.firstName;
    this.candidateRequest.lastName = this.lastName;
    this.candidateRequest.phoneNumber = this.phoneNumber;
    this.candidateRequest.biography = this.biography;
    this.candidateRequest.resume = this.resume;
    this.candidateRequest.location = this.location;
    this.candidateRequest.skills = this.skills
    this.candidateRequest.userGID = localStorage.getItem("USER_GID");

    console.log(this.candidateRequest)

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

  public addSkill() {
    this.skills.push(new Skill(this.skill));
  }
}
