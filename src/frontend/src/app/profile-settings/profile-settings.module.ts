import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidateSettingsComponent } from './candidate-settings/candidate-settings.component';
import { RecruiterSettingsComponent } from './recruiter-settings/recruiter-settings.component';
import {SharedModule} from "../shared/shared.module";
import {FormsModule} from "@angular/forms";
import {ProfileSettingsRoutingModule} from "./profile-settings-routing.module";



@NgModule({
  declarations: [
    CandidateSettingsComponent,
    RecruiterSettingsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ProfileSettingsRoutingModule
  ]
})
export class ProfileSettingsModule { }
