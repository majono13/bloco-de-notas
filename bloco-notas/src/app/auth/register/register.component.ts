//Angular
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

//Models e validators
import { CreateUser } from 'src/app/models/createUser.model';
import { ValidatorPassword } from 'src/app/validators/check-password-validator';

//Serviços
import { Snackbar } from 'src/app/shared/services/snackbar.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  userForm!: FormGroup;
  waitingResponse: boolean = false;

  constructor(
    private _fb: FormBuilder,
    private _authService: AuthService,
    private _snackbar: Snackbar,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.startsForm();
  }

  startsForm() {
    this.userForm = this._fb.group({
      firstname: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(70),
        ],
      ],
      lastname: ['', [Validators.required, Validators.maxLength(70)]],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(20),
          ValidatorPassword.checkPasswordFormat,
        ],
      ],
      rePassword: [
        '',
        [Validators.required, ValidatorPassword.checkPasswordEqual],
      ],
    });
  }

  register() {
    const newUser: CreateUser = {
      UserName: this.userForm.value.email,
      FirstName: this.userForm.value.firstname,
      LastName: this.userForm.value.lastname,
      Email: this.userForm.value.email,
      Password: this.userForm.value.password,
    };

    console.log(newUser);

    this.waitingResponse = true;

    this._authService.newUser(newUser).subscribe({
      error: (err) => {
        this.waitingResponse = false;
        this._snackbar.notify(err?.error);
      },
      next: (res) => {
        this.waitingResponse = false;
        this._router.navigateByUrl('/login');
      },
    });
  }
}
