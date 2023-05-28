import { Component } from '@angular/core';
import { LoaderService } from './loader.service';

@Component({
    selector: 'app-loader',
    templateUrl: './loader.component.html',
    styleUrls: ['./loader.component.scss'],
})
export class LoaderComponent {
    private requestsWithLoaderInProgress: number = 0;

    constructor(private readonly service: LoaderService) {
        this.service.shouldShowLoader.subscribe(value => {
            if (!!value) {
                this.requestsWithLoaderInProgress += 1;
            } else {
                this.requestsWithLoaderInProgress -= 1;
            }
        });
    }

    get shouldShowLoader(): boolean {
        return this.requestsWithLoaderInProgress === 0;
    }
}
