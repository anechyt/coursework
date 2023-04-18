import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { RecruiterCreateComponent } from "./recruiter-create/recruiter-create.component";
import { RecruiterHomeComponent } from "./recruiter-home/recruiter-home.component";
import { RecruiterLayoutComponent } from "./recruiter-layout/recruiter-layout.component";
import { RecruiterCandidatesComponent } from "./recruiter-candidates/recruiter-candidates.component";
import { RecruiterVacanciesComponent } from "./recruiter-vacancies/recruiter-vacancies.component";
import  { RecruiterStatisticsComponent } from "./recruiter-statistics/recruiter-statistics.component";

const routes: Routes = [
  { path: '', component: RecruiterLayoutComponent, children: [
      { path: 'home', component: RecruiterHomeComponent },
      { path: 'candidates', component: RecruiterCandidatesComponent },
      { path: 'vacancies', component: RecruiterVacanciesComponent },
      { path: 'statistics', component: RecruiterStatisticsComponent }
    ]
  },
  { path: 'create', component: RecruiterCreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
