import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecruiterAllVacanciesComponent } from './recruiter-all-vacancies.component';

describe('RecruiterAllVacanciesComponent', () => {
  let component: RecruiterAllVacanciesComponent;
  let fixture: ComponentFixture<RecruiterAllVacanciesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecruiterAllVacanciesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecruiterAllVacanciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
