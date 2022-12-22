import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Notes } from 'src/app/models/notes.model';
import { NotesService } from '../services/notes.service';
import { Snackbar } from 'src/app/shared/services/snackbar.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  note$!: Observable<Notes>;

  constructor(
    private _route: ActivatedRoute,
    private _notesService: NotesService,
    private _snackBar: Snackbar,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this.getNoteById();
  }

  getNoteById() {
    const id = this._route.snapshot.paramMap.get('id');

    this.note$ = this._notesService.getNoteById(id);
  }

  deleteNote(id: number) {
    this._notesService.deleteNote(id.toString()).subscribe({
      error: (err) => this._snackBar.notify(err?.error),
      next: () => {
        this._router.navigateByUrl('/user');
        this._snackBar.notify('Nota excluída!');
      },
    });
  }
}
