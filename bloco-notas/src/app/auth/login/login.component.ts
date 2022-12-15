//Angular
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { Router } from '@angular/router';

//Serviços
import { AuthService } from '../services/auth.service';
import { HttpResponseMessageService } from 'src/app/shared/services/http-response-message.service';

//Models
import { LoginRequest } from 'src/app/models/loginRequest.model';
import { Error } from 'src/app/models/error.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  @ViewChild('form') form: NgForm;

  loginForm!: FormGroup;
  waitingResponse: boolean = false;
  loginError!: Error;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private _httpResponseMessage: HttpResponseMessageService,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.startsForm();
  }

  startsForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4)]],
    });
  }

  login() {
    this.waitingResponse = true;
    const credentials: LoginRequest = {
      Email: this.loginForm.value.email,
      Password: this.loginForm.value.password,
    };

    this.authService.login(credentials).subscribe({
      error: (err) => {
        this.waitingResponse = false;
        this.showError(err);
      },
      next: (res: any) => {
        this.waitingResponse = false;
        this._router.navigateByUrl('/user');
      },
    });
  }

  showError(err: any) {
    this.loginError = {
      error: true,
      message: this._httpResponseMessage.validateMessageResponse(err?.error),
    };

    setTimeout(() => this.clearError(), 3000);
  }

  clearError() {
    this.loginError = { error: false, message: '' };
    this.clearFields();
  }

  clearFields() {
    this.form.resetForm();
  }
}
