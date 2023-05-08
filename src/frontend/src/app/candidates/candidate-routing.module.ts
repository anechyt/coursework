import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CandidateLayoutComponent } from "./candidate-layout/candidate-layout.component";
import { CandidateHomeComponent } from "./candidate-home/candidate-home.component";

const routes: Routes = [
  { path: '', component: CandidateLayoutComponent, children: [
      { path: 'home', component: CandidateHomeComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidateRoutingModule { }
