import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorPassword } from 'src/app/validators/check-password-validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  userForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.startsForm();
  }

  startsForm() {
    this.userForm = this.fb.group({
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
    console.log(this.userForm.value);
  }
}
