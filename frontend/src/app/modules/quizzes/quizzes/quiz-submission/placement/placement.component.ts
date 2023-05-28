import { Component, OnInit } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { DialogPlacement } from '../../../models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-placement',
  templateUrl: './placement.component.html',
  styleUrls: ['./placement.component.scss']
})
export class PlacementComponent implements OnInit {

  quizTitle: string = '';
  result: string = '';

  constructor(private router: Router, protected dialogRef: NbDialogRef<DialogPlacement>) { }

  ngOnInit() {
    this.quizTitle = this.dialogRef.componentRef.instance.quizTitle;
    this.result = this.dialogRef.componentRef.instance.result;
  }

  close() {
    this.dialogRef.close();
    this.router.navigate(['/quizzes']);
  }
}
