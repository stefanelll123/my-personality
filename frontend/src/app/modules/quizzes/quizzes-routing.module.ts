import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { QuizzesComponent } from './quizzes/quizzes.component';
import { QuizSubmissionComponent } from './quizzes/quiz-submission/quiz-submission.component';
import { QuizEditComponent } from './quizzes/quiz-edit/quiz-edit.component';
import { AuthGuardService } from 'src/app/shared/auth-guard.service';

const routes: Routes = [
  { path: ':id/edit', component: QuizEditComponent, canActivate: [AuthGuardService] },
  { path: ':id', component: QuizSubmissionComponent },
  { path: '', component: QuizzesComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuizzesRoutingModule { }
