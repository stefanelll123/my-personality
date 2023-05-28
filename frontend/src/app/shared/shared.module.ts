import { NgModule } from '@angular/core';
import { NbMomentDateModule } from '@nebular/moment';
import { NbAccordionModule, NbButtonModule, NbCardModule, NbCheckboxModule, NbDatepickerModule, NbDialogModule, NbIconModule, NbInputModule, NbLayoutModule, NbRadioModule, NbSpinnerModule, NbStepperModule, NbTabsetModule } from '@nebular/theme';

@NgModule({
  declarations: [
  ],
  imports: [
    NbDialogModule.forChild()
  ],
  exports: [
    NbInputModule,
    NbCardModule,
    NbIconModule,
    NbButtonModule,
    NbLayoutModule,
    NbSpinnerModule,
    NbCheckboxModule,
    NbDialogModule,
    NbDatepickerModule,
    NbMomentDateModule,
    NbTabsetModule,
    NbAccordionModule,
    NbStepperModule,
    NbRadioModule,
  ]
})
export class SharedModule { }
