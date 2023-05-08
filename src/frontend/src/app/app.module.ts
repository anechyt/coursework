import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AuthModule } from "./auth/auth.module";
import { SharedModule } from "./shared/shared.module";
import { HttpClientModule } from "@angular/common/http";
import { CandidatesModule } from "./candidates/candidates.module";
import { RecruitersModule } from "./recruiters/recruiters.module";
import { ProfileSettingsModule } from "./profile-settings/profile-settings.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AuthModule,
    SharedModule,
    HttpClientModule,
    CandidatesModule,
    RecruitersModule,
    ProfileSettingsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
