import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToolBarComponent } from "./tool-bar.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { RouterLink } from "@angular/router";
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { ReactiveFormsModule } from "@angular/forms";
import { MatInputModule } from "@angular/material/input";
import { MatDialogModule } from "@angular/material/dialog";

@NgModule({
  declarations: [
    ToolBarComponent,
    SignInComponent,
    SignUpComponent
  ],
  exports: [
    ToolBarComponent
  ],
  imports: [
    CommonModule,
    MatToolbarModule,
    RouterLink,
    ReactiveFormsModule,
    MatInputModule,
    MatDialogModule
  ]
})
export class ToolBarModule { }
