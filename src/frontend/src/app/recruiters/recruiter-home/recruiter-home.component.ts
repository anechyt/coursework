import { Component, OnInit } from '@angular/core';
import { RecruiterService } from "../services/recruiter.service";
import { Router } from "@angular/router";
import {Observable} from "rxjs";
import { CandidatesResponse } from "../../candidates/models/candidates-response";

@Component({
  selector: 'app-recruiter-home',
  templateUrl: './recruiter-home.component.html',
  styleUrls: ['./recruiter-home.component.scss']
})
export class RecruiterHomeComponent implements OnInit {
  public candidates$!: Observable<CandidatesResponse[]>;

  public firstName: string | null = null;
  public lastName: string | null = null;
  public location: string | null = null;

  constructor(private recruiterService: RecruiterService,
              private router: Router) { }

  ngOnInit(): void {
    this.location = localStorage.getItem("LOCATION");
    const userGID = localStorage.getItem("USER_GID") || "";

    this.candidates$ = this.recruiterService.getCandidatesNearbyRecruiter(userGID, 100);
  }
}
