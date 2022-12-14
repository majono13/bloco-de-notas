import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from 'src/app/auth/services/token.service';
import { Notes } from 'src/app/models/notes.model';
import { NotesService } from '../services/notes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  notes$!: Observable<Notes[]>;

  constructor(
    private _notesService: NotesService,
    private _tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getNotes();
  }

  getNotes() {
    if (this._tokenService.getToken()) {
      this.notes$ = this._notesService.getNotesUser();
    }
  }
}
