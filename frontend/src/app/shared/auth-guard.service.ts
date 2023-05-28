import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthGuardService implements CanActivate {
  jwtHelper: JwtHelperService = new JwtHelperService();

  constructor(public router: Router) {}

  canActivate(): boolean {
    if (!this.isAuthenticated()) {
      localStorage.removeItem('token');
      this.router.navigate(['/identity/login']);
      return false;
    }

    return true;
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    if (!token) {
      return false;
    }

    return !this.jwtHelper.isTokenExpired(token);
  }
}
