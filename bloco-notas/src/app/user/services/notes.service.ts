//Imports Angular
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';

//RXJS
import { map, Observable } from 'rxjs';

//Serviços
import { AuthService } from 'src/app/auth/services/auth.service';
import { TokenService } from 'src/app/auth/services/token.service';

//Models
import { Notes } from 'src/app/models/notes.model';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root',
})
export class NotesService {
  private readonly url = environment.url;
  private user: User;
  notes$: Observable<Notes[]>;

  constructor(
    private _authService: AuthService,
    private http: HttpClient,
    private _tokenService: TokenService
  ) {}

  getNotesUser() {
    return this._authService.getUser().pipe(map((user) => user?.notes));
  }
}
