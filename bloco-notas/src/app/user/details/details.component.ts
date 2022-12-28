import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Notes } from 'src/app/models/notes.model';
import { NotesService } from '../services/notes.service';
import { Snackbar } from 'src/app/shared/services/snackbar.service';
import { MatDialog } from '@angular/material/dialog';
import { EditComponent } from '../edit/edit.component';

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
    private _router: Router,
    public dialog: MatDialog
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
      next: () => this.success('Nota excluída!'),
    });
  }

  archiveNote(note: Notes) {
    note.isFiled = !note.isFiled;
    this._notesService.editNote(note).subscribe({
      error: (err) => this._snackBar.notify(err?.error),
      next: () => this.success('Nota arquivada!'),
    });
  }

  success(msg: string) {
    this._router.navigateByUrl('/user');
    this._snackBar.notify(msg);
  }

  openDialog(note: Notes) {
    const dialogRef = this.dialog.open(EditComponent, {
      data: note,
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
