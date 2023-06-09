import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidateHomeComponent } from './candidate-home/candidate-home.component';
import { CandidateLayoutComponent } from './candidate-layout/candidate-layout.component';
import { SharedModule } from "../shared/shared.module";
import { FormsModule } from "@angular/forms";
import { CandidateRoutingModule } from "./candidate-routing.module";
import { CandidateHeaderComponent } from './candidate-header/candidate-header.component';
import { CandidateVacanciesComponent } from './candidate-vacancies/candidate-vacancies.component';



@NgModule({
  declarations: [
    CandidateHomeComponent,
    CandidateLayoutComponent,
    CandidateHeaderComponent,
    CandidateVacanciesComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    CandidateRoutingModule
  ]
})
export class CandidatesModule { }
