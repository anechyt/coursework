import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthCandidateGuard } from "./shared/guards/auth-candidate.guard";
import { AuthRecruiterGuard } from "./shared/guards/auth-recruiter.guard";

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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
