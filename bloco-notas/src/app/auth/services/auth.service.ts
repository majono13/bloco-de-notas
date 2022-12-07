import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateUser } from 'src/app/models/createUser.model';
import { LoginRequest } from 'src/app/models/loginRequest.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly url: string = environment.url;

  constructor(private http: HttpClient) {}

  newUser(user: CreateUser): Observable<CreateUser> {
    return this.http.post<CreateUser>(`${this.url}/register`, user);
  }

  login(credentials: LoginRequest) {
    return this.http.post(`${this.url}/login`, credentials);
  }
}
