import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthCandidateGuard } from "./shared/guards/auth-candidate.guard";
import { AuthRecruiterGuard } from "./shared/guards/auth-recruiter.guard";
import {IsAuthGuard} from "./shared/guards/is-auth.guard";

const routes: Routes = [
  { path: '',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule)
  },
  { path: 'role-candidate',
    loadChildren: () => import('./candidates/candidates.module').then((m) => m.CandidatesModule),
    canActivate: [AuthCandidateGuard]
  },
  { path: 'role-recruiter',
    loadChildren: () => import('./recruiters/recruiters.module').then((m) => m.RecruitersModule),
    canActivate: [AuthRecruiterGuard]
  },
  { path: 'profile-settings',
    loadChildren: () => import('./profile-settings/profile-settings.module').then((m) => m.ProfileSettingsModule),
    canActivate: [IsAuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
