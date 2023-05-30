import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Vacancy } from "../models/vacancy";
import { Skill } from "../../candidates/models/skill";
import {VacancyService} from "../services/vacancy.service";

@Component({
  selector: 'app-create-vacancy-modal',
  templateUrl: './create-vacancy-modal.component.html',
  styleUrls: ['./create-vacancy-modal.component.scss']
})
export class CreateVacancyModalComponent implements OnInit {

  public skill: string = '';
  public name: string | null = null;
  public description: string | null = null;
  public location: string | null = null;
  public salary: string | null = null;
  public skills: Array<Skill> = [];
  public vacancyRequest!: Vacancy;
  @Input() recruiterGid: string | null = null;
  @Output() close: EventEmitter<number> = new EventEmitter<number>();
  constructor(private vacancyService: VacancyService) { }

  ngOnInit(): void {
  }

  public closeModal(): void {
    this.close.emit(-1);
  }

  public addVacancy(): void {
    this.vacancyRequest = {
      name: '',
      description: '',
      location: '',
      salary: 0,
      skills: [],
      vacancyStatusGID: '',
      recruiterGID: ''
    }

    this.vacancyRequest.name = this.name;
    this.vacancyRequest.description = this.description;
    this.vacancyRequest.location = this.location;
    this.vacancyRequest.salary = parseInt(this.salary ?? '0');
    this.vacancyRequest.skills = this.skills;
    this.vacancyRequest.vacancyStatusGID = '5cd7abac-18d7-43be-fc08-08db612a8cc4';
    this.vacancyRequest.recruiterGID = this.recruiterGid;

    this.vacancyService.createVacancy(this.vacancyRequest).subscribe((data) => {
      this.close.emit(-1);
    },(error) => {
      console.log(error);
    })
  }

  public addSkill(): void {
    this.skills.push(new Skill(this.skill));
  }
}
