import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/shared/http.service';
import { Quiz, QuizSubmissionPlacement, validateQuiz, validateQuizSubmissionPlacement } from './models';
import { expectArray } from 'src/app/shared/validation';
import { QuizSubmission } from './models/quiz-submission.model';

const validateQuizzesArray = (value: unknown) => expectArray(value).map(validateQuiz);

@Injectable({
    providedIn: 'root',
})
export class QuizzesService {

  constructor(private http: HttpService) {}

  getQuizzes(): Observable<Quiz[]> {
    return this.http.getWithLoader<Quiz[]>(environment.quizzesUri)
    .pipe(map(validateQuizzesArray));;
  }

  getQuiz(id: string): Observable<Quiz> {
    return this.http.getWithLoader<Quiz>(`${environment.quizzesUri}/${id}`)
    .pipe(map(validateQuiz));
  }

  createQuizSubmission(quizSubmission: QuizSubmission): Observable<string> {
    return this.http.postWithLoader(environment.quizSubmissionUri, quizSubmission);
  }

  getPlacement(quizId: string, quizSubmissionId: string): Observable<QuizSubmissionPlacement> {
    return this.http.getWithLoader(`${environment.quizzesUri}/${quizId}/${quizSubmissionId}/placement`)
      .pipe(map(validateQuizSubmissionPlacement));
  }
}
