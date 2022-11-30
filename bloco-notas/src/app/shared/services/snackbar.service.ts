import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpResponseMessageService } from './http-response-message.service';

@Injectable({
  providedIn: 'root',
})
export class Snackbar {
  constructor(
    private _snackbar: MatSnackBar,
    private _httpResponseMessage: HttpResponseMessageService
  ) {}

  notify(message: any) {
    const msg = this._httpResponseMessage.validateMessageResponse(message);

    this._snackbar.open(msg, 'Ok', { duration: 3000 });
  }
}
