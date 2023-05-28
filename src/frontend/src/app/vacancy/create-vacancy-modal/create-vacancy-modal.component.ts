import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-create-vacancy-modal',
  templateUrl: './create-vacancy-modal.component.html',
  styleUrls: ['./create-vacancy-modal.component.scss']
})
export class CreateVacancyModalComponent implements OnInit {

  public skill: string | null = null;
  public name: string | null = null;
  public description: string | null = null;
  public location: string | null = null;
  public salary: string | null = null;
  public skills: string[] = [];
  @Output() close: EventEmitter<number> = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  public closeModal(): void {
    this.close.emit(-1);
  }

  public addVacancy(): void {

  }

  public addSkill(): void {
    this.skills.push(this.skill ?? '');
  }
}
