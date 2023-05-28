import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AnswerSubmission, Question, Quiz } from '../../models';
import { QuizzesService } from '../../quizzes.service';
import { FormControl, Validators } from '@angular/forms';
import { QuizSubmission } from '../../models/quiz-submission.model';
import { NbDialogService } from '@nebular/theme';
import { PlacementComponent } from './placement/placement.component';

@Component({
  selector: 'app-quiz-submission',
  templateUrl: './quiz-submission.component.html',
  styleUrls: ['./quiz-submission.component.scss'],
})
export class QuizSubmissionComponent implements OnInit {
  quizId: string | null = null;
  quiz: Quiz | null = null;

  questionAnswerForms: {[key: string]: FormControl} = {};

  get questions(): Question[] {
    return this.quiz?.questions ?? [];
  }

  constructor(private route: ActivatedRoute, private router: Router,
              private dialogService: NbDialogService, private service: QuizzesService) { }

  ngOnInit() {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.quizId = params.get('id');
      if(!this.quizId) {
        this.router.navigate(['/quizzes']);
        return;
      }

      this.service.getQuiz(this.quizId)
        .subscribe({
          next: quiz => {
            this.quiz = quiz;
            for(let question of this.quiz.questions) {
              this.questionAnswerForms[question.id] = new FormControl('', Validators.required);
            }
          },
          error: _ => this.router.navigate(['/quizzes'])
        });
    });
  }

  isQuestionAnswerd(questionId: string): boolean {
    return this.questionAnswerForms[questionId].valid;
  }

  createQuizSubmission(): void {
    if (!this.quiz?.id || this.quiz.questions.length === 0) {
      return;
    }

    const quizSubmission: QuizSubmission = {
      quizId: this.quiz.id,
      answerSubmissions: this.questions.map(this.createAnswerSubmission.bind(this))
    }
    this.service.createQuizSubmission(quizSubmission).subscribe(quizSubmissionId => {
      this.service.getPlacement(this.quiz?.id!, quizSubmissionId).subscribe(placement => {
        this.dialogService.open(PlacementComponent, {context: {quizTitle: this.quiz?.title, result: placement.value}});
      })
    });
  }

  private createAnswerSubmission(question: Question): AnswerSubmission {
    return {
      questionId: question.id,
      answerId: this.questionAnswerForms[question.id].value
    }
  }
}
