import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TokenService {
  readonly key: string = 'token';

  constructor() {}

  setToken(token: string) {
    localStorage.setItem(this.key, token);
  }

  getToken(): string {
    return localStorage.getItem(this.key);
  }

  removeToken() {
    localStorage.removeItem(this.key);
  }
}
