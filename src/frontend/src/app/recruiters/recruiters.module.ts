import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecruiterHomeComponent } from './recruiter-home/recruiter-home.component';
import { RecruiterCreateComponent } from './recruiter-create/recruiter-create.component';
import { RecruiterRoutingModule } from "./recruiter-routing.module";
import { SharedModule } from "../shared/shared.module";
import { FormsModule } from "@angular/forms";
import { RecruiterLayoutComponent } from './recruiter-layout/recruiter-layout.component';
import { RecruiterHeaderComponent } from './recruiter-header/recruiter-header.component';
import { RecruiterCandidatesComponent } from './recruiter-candidates/recruiter-candidates.component';
import { RecruiterVacanciesComponent } from './recruiter-vacancies/recruiter-vacancies.component';
import { RecruiterStatisticsComponent } from './recruiter-statistics/recruiter-statistics.component';

@NgModule({
  declarations: [
    RecruiterHomeComponent,
    RecruiterCreateComponent,
    RecruiterLayoutComponent,
    RecruiterHeaderComponent,
    RecruiterCandidatesComponent,
    RecruiterVacanciesComponent,
    RecruiterStatisticsComponent
  ],
  imports: [
    CommonModule,
    RecruiterRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class RecruitersModule { }
