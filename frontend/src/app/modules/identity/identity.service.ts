import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { HttpService } from 'src/app/shared/http.service';

import { Login, LoginResponse } from './models';

@Injectable({
    providedIn: 'root',
})
export class IdentityService {

    constructor(private http: HttpService) {}

    login(login: Login): Observable<LoginResponse> {
      return this.http.postWithLoader<LoginResponse>(environment.loginUri, login);
    }
}
