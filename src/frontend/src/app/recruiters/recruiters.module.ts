import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecruiterHomeComponent } from './recruiter-home/recruiter-home.component';
import { RecruiterRoutingModule } from "./recruiter-routing.module";
import { SharedModule } from "../shared/shared.module";
import { FormsModule } from "@angular/forms";
import { RecruiterLayoutComponent } from './recruiter-layout/recruiter-layout.component';
import { RecruiterHeaderComponent } from './recruiter-header/recruiter-header.component';
import { RecruiterCandidatesComponent } from './recruiter-candidates/recruiter-candidates.component';
import { RecruiterVacanciesComponent } from './recruiter-vacancies/recruiter-vacancies.component';
import { RecruiterStatisticsComponent } from './recruiter-statistics/recruiter-statistics.component';
import { VacancyModule } from "../vacancy/vacancy.module";
import { RecruiterAllVacanciesComponent } from './recruiter-all-vacancies/recruiter-all-vacancies.component';


@NgModule({
  declarations: [
    RecruiterHomeComponent,
    RecruiterLayoutComponent,
    RecruiterHeaderComponent,
    RecruiterCandidatesComponent,
    RecruiterVacanciesComponent,
    RecruiterStatisticsComponent,
    RecruiterAllVacanciesComponent
  ],
  imports: [
    CommonModule,
    RecruiterRoutingModule,
    SharedModule,
    FormsModule,
    VacancyModule
  ]
})
export class RecruitersModule { }
