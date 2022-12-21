import { Injectable } from '@angular/core';
import { Token } from 'src/app/models/token.model';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  readonly key: string = 'token';

  constructor() {}

  setToken(token: string) {
    localStorage.setItem(this.key, token);
  }

  getToken(): Token {
    const token: Token = { value: localStorage.getItem(this.key) };

    return token;
  }

  removeToken() {
    localStorage.removeItem(this.key);
  }
}
