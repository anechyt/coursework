import { Component, OnInit } from '@angular/core';
import { CandidateService } from "../services/candidate.service";
import {Router} from "@angular/router";
import {Observable} from "rxjs";
import {CandidatesResponse} from "../models/candidates-response";
import {VacancyService} from "../../vacancy/services/vacancy.service";
import {VacancyResponse} from "../../vacancy/models/vacancy-response";

@Component({
  selector: 'app-candidate-home',
  templateUrl: './candidate-home.component.html',
  styleUrls: ['./candidate-home.component.scss']
})
export class CandidateHomeComponent implements OnInit {

  public vacancies$!: Observable<VacancyResponse[]>;

  public firstName: string | null = null;
  public lastName: string | null = null;
  public location: string | null = null;


  constructor(private vacancyService: VacancyService,
              private router: Router) { }

  ngOnInit(): void {
    this.location = localStorage.getItem("LOCATION");
    const userGID = localStorage.getItem("USER_GID") || "";

    this.vacancies$ = this.vacancyService.getVacanciesNearbyCandidate(userGID, 100);
  }
}
