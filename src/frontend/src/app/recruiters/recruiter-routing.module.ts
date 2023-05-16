import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { RecruiterHomeComponent } from "./recruiter-home/recruiter-home.component";
import { RecruiterLayoutComponent } from "./recruiter-layout/recruiter-layout.component";
import { RecruiterCandidatesComponent } from "./recruiter-candidates/recruiter-candidates.component";
import { RecruiterVacanciesComponent } from "./recruiter-vacancies/recruiter-vacancies.component";
import  { RecruiterStatisticsComponent } from "./recruiter-statistics/recruiter-statistics.component";

const routes: Routes = [
  { path: '', component: RecruiterLayoutComponent, children: [
      { path: 'recruiter-home', component: RecruiterHomeComponent },
      { path: 'recruiter-candidates', component: RecruiterCandidatesComponent },
      { path: 'recruiter-vacancies', component: RecruiterVacanciesComponent },
      { path: 'recruiter-statistics', component: RecruiterStatisticsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruiterRoutingModule { }
