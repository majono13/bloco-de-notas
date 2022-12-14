//Imports Angular
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';

//RXJS
import { map, Observable } from 'rxjs';

//Serviços
import { TokenService } from 'src/app/auth/services/token.service';

//Models
import { Notes } from 'src/app/models/notes.model';

@Injectable({
  providedIn: 'root',
})
export class NotesService {
  private readonly url = environment.url;
  notes$: Observable<Notes[]>;

  constructor(private http: HttpClient, private _tokenService: TokenService) {}

  getNotesUser(): Observable<Notes[]> {
    return this.http.post<Notes[]>(
      `${this.url}/get-notes`,
      this._tokenService.getToken()
    );
  }

  getNoteById(id: string): Observable<Notes> {
    return this.http.get<Notes>(`${this.url}/note/${id}`);
  }

  deleteNote(id: string) {
    return this.http.delete(`${this.url}/note/${id}`);
  }

  editNote(note: Notes) {
    return this.http.post(`${this.url}/edit`, note);
  }
}
