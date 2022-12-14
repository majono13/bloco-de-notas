//Imports Angular
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';

//RXJS
import { BehaviorSubject, map, Observable, tap, catchError, of } from 'rxjs';
import { CreateUser } from 'src/app/models/createUser.model';

//Models
import { LoginRequest } from 'src/app/models/loginRequest.model';
import { Token } from 'src/app/models/token.model';
import { User } from 'src/app/models/user.model';

//Serviços
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly url: string = environment.url;
  subjUser$: BehaviorSubject<User> = new BehaviorSubject<User>(null);
  subjLoggedIn$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor(private http: HttpClient, private _tokenService: TokenService) {}

  newUser(user: CreateUser): Observable<CreateUser> {
    return this.http.post<CreateUser>(`${this.url}/register`, user);
  }

  login(credentials: LoginRequest) {
    return this.http.post<User>(`${this.url}/login`, credentials).pipe(
      tap((user) => {
        this._tokenService.setToken(user.token);
        this.subjLoggedIn$.next(true);
        this.subjUser$.next(user);
      })
    );
  }

  isAuthenticated(): Observable<boolean> {
    const token: Token = { value: this._tokenService.getToken() };

    if (token.value != null && !this.subjLoggedIn$.value) {
      return this.checkTokenValidation(token);
    }

    return this.subjLoggedIn$.asObservable();
  }

  checkTokenValidation(token: Token): Observable<boolean> {
    return this.http.post<User>(`${this.url}/token`, token).pipe(
      tap((user: User) => {
        if (user) {
          this.subjLoggedIn$.next(true);
          this.subjUser$.next(user);
        }
      }),
      map((user: User) => (user ? true : false)),
      catchError((err) => {
        this.logout();
        return of(false);
      })
    );
  }

  getUser(): Observable<User> {
    return this.subjUser$.asObservable();
  }

  logout() {
    this._tokenService.removeToken();
    this.subjLoggedIn$.next(false);
    this.subjUser$.next(null);
  }
}
