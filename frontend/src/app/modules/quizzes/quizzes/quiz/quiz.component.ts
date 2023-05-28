import { Component, Input, OnInit } from '@angular/core';
import { Quiz } from '../../models';
import { Router } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/auth-guard.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.scss']
})
export class QuizComponent {

  @Input() quiz!: Quiz;

  constructor(private router: Router, public authService: AuthGuardService) { }

  openQuizSubmission(): void {
    this.router.navigate(['/quizzes', this.quiz.id])
  }

  openEditQuizSubmission(): void {
    this.router.navigate(['/quizzes', this.quiz.id, 'edit'])
  }
}
