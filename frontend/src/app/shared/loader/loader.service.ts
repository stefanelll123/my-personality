import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root',
})
export class LoaderService {
    public shouldShowLoader = new BehaviorSubject(false);

    public hideLoader(): void {
        this.shouldShowLoader.next(false);
    }

    public showLoader(): void {
        this.shouldShowLoader.next(true);
    }
}
