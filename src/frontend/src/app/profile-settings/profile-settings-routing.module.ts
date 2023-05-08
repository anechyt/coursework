import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CandidateSettingsComponent } from "./candidate-settings/candidate-settings.component";
import { RecruiterSettingsComponent } from "./recruiter-settings/recruiter-settings.component";

const routes: Routes = [
  { path: 'candidate-settings', component: CandidateSettingsComponent },
  { path: 'recruiter-settings', component: RecruiterSettingsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileSettingsRoutingModule { }
