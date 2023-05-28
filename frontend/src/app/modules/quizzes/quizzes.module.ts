import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';
import { QuizzesRoutingModule } from './quizzes-routing.module';
import { QuizzesComponent } from './quizzes/quizzes.component';
import { QuizComponent } from './quizzes/quiz/quiz.component';
import { QuizSubmissionComponent } from './quizzes/quiz-submission/quiz-submission.component';
import { PlacementComponent } from './quizzes/quiz-submission/placement/placement.component';
import { QuizEditComponent } from './quizzes/quiz-edit/quiz-edit.component';

@NgModule({
  declarations: [
    QuizzesComponent,
    QuizComponent,
    QuizSubmissionComponent,
    PlacementComponent,
    QuizEditComponent
  ],
  imports: [
    CommonModule,
    QuizzesRoutingModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class QuizzesModule { }
