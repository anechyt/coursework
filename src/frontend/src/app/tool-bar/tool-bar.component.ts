import { Component, OnInit } from '@angular/core';
import { SignUpComponent } from "./sign-up/sign-up.component";
import { SignInComponent } from "./sign-in/sign-in.component";
import { MatDialog } from "@angular/material/dialog";

@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss']
})
export class ToolBarComponent implements OnInit {

  constructor(private authDialogContainer: MatDialog) { }

  ngOnInit(): void {
  }

  openAuthDialog(isSignUp: boolean): void {
    if (isSignUp) {
      this.authDialogContainer.open(SignUpComponent, { panelClass: 'auth-dialog-container' });
    }
    else {
      this.authDialogContainer.open(SignInComponent, { panelClass: 'auth-dialog-container' });
    }
  }
}
