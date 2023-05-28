import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { LoaderService } from './loader/loader.service';
import { catchError, finalize } from 'rxjs/operators';
import { AlertsService } from './alerts/alerts.service';

@Injectable({
    providedIn: 'root',
})
export class HttpService {

    constructor(
      private http: HttpClient,
      private readonly loader: LoaderService,
      private readonly alerts: AlertsService) {
    }

    public get<T>(url: string, options?: {
      headers?: HttpHeaders | {
          [header: string]: string | string[];
      };
      observe?: 'body';
      params?: HttpParams | {
          [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    }): Observable<T>
    {
      return this.http.get<T>(url, options).pipe(catchError(err => {
        this.alerts.addAllert(err.error.errorMessage);
        return throwError(() => err);
      }));
    }

    public getWithLoader<T>(url: string, options?: {
      headers?: HttpHeaders | {
          [header: string]: string | string[];
      };
      observe?: 'body';
      params?: HttpParams | {
          [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    }): Observable<T>
    {
      this.loader.showLoader();
      return this.http.get<T>(url, options).pipe(finalize(() => {
          this.loader.hideLoader();
      })).pipe(catchError(err => {
        console.log(err)
        this.alerts.addAllert(err.error.errorMessage);
        return throwError(() => err);
      }));
    }

    public post<T>(url: string, body: any | null, options?: {
      headers?: HttpHeaders | {
          [header: string]: string | string[];
      };
      observe?: 'body';
      params?: HttpParams | {
          [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    }): Observable<T> {
      return this.http.post<T>(url, body, options).pipe(catchError(err => {
        this.alerts.addAllert(err.error.errorMessage);
        return throwError(() => err);
      }));
    }

    public postWithLoader<T>(url: string, body: any | null, options?: {
      headers?: HttpHeaders | {
          [header: string]: string | string[];
      };
      observe?: 'body';
      params?: HttpParams | {
          [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    }): Observable<T> {
      this.loader.showLoader();
      return this.http.post<T>(url, body, options).pipe(finalize(() => {
          this.loader.hideLoader();
      })).pipe(catchError(err => {
        this.alerts.addAllert(err.error.errorMessage);
        return throwError(() => err);
      }));
    }

    public put<T>(url: string, body: any | null, options?: {
      headers?: HttpHeaders | {
          [header: string]: string | string[];
      };
      observe?: 'body';
      params?: HttpParams | {
          [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    }): Observable<T> {
      return this.http.put<T>(url, body, options).pipe(catchError(err => {
        this.alerts.addAllert(err.error.errorMessage);
        return throwError(() => err);
      }));
    }

    public putWithLoader<T>(url: string, body: any | null, options?: {
      headers?: HttpHeaders | {
          [header: string]: string | string[];
      };
      observe?: 'body';
      params?: HttpParams | {
          [param: string]: string | string[];
      };
      reportProgress?: boolean;
      responseType?: 'json';
      withCredentials?: boolean;
    }): Observable<T> {
      this.loader.showLoader();
      return this.http.put<T>(url, body, options).pipe(finalize(() => {
          this.loader.hideLoader();
      })).pipe(catchError(err => {
        this.alerts.addAllert(err.error.errorMessage);
        return throwError(() => err);
      }));
    }
}
