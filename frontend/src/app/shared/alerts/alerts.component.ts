import { Component } from '@angular/core';
import { AlertsService } from './alerts.service';

@Component({
    selector: 'app-alerts',
    templateUrl: './alerts.component.html',
    styleUrls: ['./alerts.component.scss'],
})
export class AlertsComponent {
    constructor(public readonly service: AlertsService) {
    }

    close(id: number) {
      this.service.closeAllert(id);
    }
}
