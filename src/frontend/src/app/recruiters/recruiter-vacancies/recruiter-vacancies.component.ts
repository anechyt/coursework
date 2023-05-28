import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recruiter-vacancies',
  templateUrl: './recruiter-vacancies.component.html',
  styleUrls: ['./recruiter-vacancies.component.scss']
})
export class RecruiterVacanciesComponent implements OnInit {
  public showModal = -1;
  constructor() { }

  ngOnInit(): void {
  }

  public showCreateVacancyModal(index: any): void {
    this.showModal = index
  }

  public closeModal(event: number): void {
    this.showModal = event;
  }
}
