import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { VacancyResponse } from "../../vacancy/models/vacancy-response";
import { VacancyService } from "../../vacancy/services/vacancy.service";

@Component({
  selector: 'app-candidate-vacancies',
  templateUrl: './candidate-vacancies.component.html',
  styleUrls: ['./candidate-vacancies.component.scss']
})
export class CandidateVacanciesComponent implements OnInit {
  public skill: string | null = null;
  public bio: string | null = null;
  public resume: string | null = null;
  public skills: string[] = [];
  public bios: string[] = [];
  public resumes: string[] = [];
  public vacancies$!: Observable<VacancyResponse[]>;
  constructor(private vacancyService: VacancyService) { }

  ngOnInit(): void {
    this.vacancies$ = this.vacancyService.getVacancies();
  }

  public refreshVacancies(): void {
    this.vacancies$ = this.vacancyService.getVacancies();
    this.skills = [];
    this.bios = [];
    this.resumes = [];

    this.skill = '';
    this.bio = '';
    this.resume = '';
  }

  public addSkill(): void {
    this.skills.push(this.skill ?? '');
  }

  public addBio(): void {
    this.bios.push(this.bio ?? '');
  }

  public addResume(): void {
    this.resumes.push(this.resume ?? '');
  }

  public searchBySkills(): void {
    // this.candidates$ = this.candidateService.getCandidatesBySkills(this.skills);
  }

  public searchByBio(): void {
    // this.candidates$ = this.candidateService.getCandidatesByBio(this.bios);
  }

  public searchByResume(): void {
    // this.candidates$ = this.candidateService.getCandidatesByResume(this.resumes);
  }

}
