import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { CandidatesResponse } from "../../candidates/models/candidates-response";
import { CandidateService } from "../../candidates/services/candidate.service";

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

  constructor(private candidateService: CandidateService,
              private router: Router) { }

  ngOnInit(): void {
    this.location = localStorage.getItem("LOCATION");
    const userGID = localStorage.getItem("USER_GID") || "";

    this.candidates$ = this.candidateService.getCandidatesNearbyRecruiter(userGID, 100);
  }
}
