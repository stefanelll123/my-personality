import { Component, OnInit} from '@angular/core';
import { Quiz } from '../models';
import { QuizzesService } from '../quizzes.service';

@Component({
  selector: 'app-quizzes',
  templateUrl: './quizzes.component.html',
  styleUrls: ['./quizzes.component.scss']
})
export class QuizzesComponent implements OnInit {
  quizzes: Quiz[] = [];

  constructor(private service: QuizzesService) {}

  ngOnInit(): void {
    this.service.getQuizzes()
      .subscribe(quizzes => this.quizzes = quizzes);
  }
}
