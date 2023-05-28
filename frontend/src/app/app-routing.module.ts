import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuardService as AuthGuard } from './shared/auth-guard.service';

const routes: Routes = [
  {
    path: 'identity',
    loadChildren: () => import('./modules/identity/identity.module').then(m => m.IdentityModule)
  },
  {
    path: 'quizzes',
    loadChildren: () => import('./modules/quizzes/quizzes.module').then(m => m.QuizzesModule)
  },
  { path: '**', redirectTo: '/quizzes', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
