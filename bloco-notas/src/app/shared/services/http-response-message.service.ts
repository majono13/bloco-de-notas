import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class HttpResponseMessageService {
  constructor() {}

  validateMessageResponse(msg: any) {
    if (typeof msg === 'string') return msg;
    return 'Algo deu errado, tente novamente mais tarde';
  }
}
