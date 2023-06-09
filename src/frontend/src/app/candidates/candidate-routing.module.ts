import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CandidateLayoutComponent } from "./candidate-layout/candidate-layout.component";
import { CandidateHomeComponent } from "./candidate-home/candidate-home.component";
import { CandidateVacanciesComponent } from "./candidate-vacancies/candidate-vacancies.component";

const routes: Routes = [
  { path: '', component: CandidateLayoutComponent, children: [
      { path: 'home', component: CandidateHomeComponent },
      { path: 'vacancies', component: CandidateVacanciesComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidateRoutingModule { }
