import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateVacancyModalComponent } from "./create-vacancy-modal/create-vacancy-modal.component";
import {SharedModule} from "../shared/shared.module";


@NgModule({
  declarations: [
    CreateVacancyModalComponent
  ],
  exports: [
    CreateVacancyModalComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class VacancyModule { }
