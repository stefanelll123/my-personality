import { Component} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IdentityService } from '../identity.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({
    email: new FormControl('', {
      validators: [Validators.required, Validators.email, Validators.minLength(7), Validators.maxLength(100)],
      updateOn: 'blur'
    }),
    password: new FormControl('', {
      validators: [Validators.required, Validators.minLength(7), Validators.maxLength(50)],
      updateOn: 'blur'
    })
  });

  constructor(
    public router: Router,
    public readonly service: IdentityService) {
  }

  redirectToPasswordRecorery(): void {
    this.router.navigate(['/identity/recovery']);
  }

  onSubmit(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.service.login({
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value,
    }).subscribe(response => {
      localStorage.setItem('token', response.token);
      localStorage.setItem('firstName', response.firstName);
      localStorage.setItem('lastName', response.lastName);
      this.router.navigate(['/events']);
    });
  }
}
