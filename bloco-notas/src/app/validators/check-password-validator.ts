import { AbstractControl, FormGroup } from '@angular/forms';

export class ValidatorPassword {
  static checkPasswordEqual(control: FormGroup) {
    if (!control.parent) return null;

    const password = control.parent.get('password')?.value ?? '';
    const rePassword = control.parent.get('rePassword')?.value ?? '';

    if (password == rePassword) return null;

    return { matchingPassword: true };
  }

  static checkPasswordFormat(control: FormGroup) {
    if (!control.parent) return null;

    let password: string = control.parent.get('password')?.value ?? '';

    if (
      password.match('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-])')
    )
      return null;

    return { invalidFormat: true };
  }
}
