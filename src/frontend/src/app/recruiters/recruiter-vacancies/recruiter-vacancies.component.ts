import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { RecruiterService } from "../services/recruiter.service";
import { Observable, Subscription } from "rxjs";
import { RecruiterResponse } from "../models/recruiter-response";
import { VacancyResponse } from "../../vacancy/models/vacancy-response";
import { VacancyService } from "../../vacancy/services/vacancy.service";

@Component({
  selector: 'app-recruiter-vacancies',
  templateUrl: './recruiter-vacancies.component.html',
  styleUrls: ['./recruiter-vacancies.component.scss']
})
export class RecruiterVacanciesComponent implements OnInit, OnDestroy {
  public showModal = -1;

  public recruiter$!: Observable<RecruiterResponse>;
  public vacancies$!: Observable<VacancyResponse[]>;
  public recruiterGid: string | null = null;
  private recruiterSubscription: Subscription | undefined;
  constructor(private recruiterService: RecruiterService,
              private vacancyService: VacancyService) { }

   async ngOnInit(): Promise<void> {
    const userGID = localStorage.getItem("USER_GID") || "";
    this.recruiter$ = await this.recruiterService.getRecruiterByUserGid(userGID);
    var recruiter = await this.recruiter$.toPromise();
    this.recruiterGid = recruiter?.gid ?? '';

    this.vacancies$ = this.vacancyService.getVacanciesByRecruiterGID(this.recruiterGid ?? '');
  }

  public showCreateVacancyModal(index: any): void {
    this.showModal = index
  }

  public closeModal(event: number): void {
    this.showModal = event;
  }

  ngOnDestroy(): void {
    if (this.recruiterSubscription) {
      this.recruiterSubscription.unsubscribe();
    }
  }
}
