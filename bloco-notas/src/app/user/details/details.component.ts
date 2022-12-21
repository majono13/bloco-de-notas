import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Notes } from 'src/app/models/notes.model';
import { NotesService } from '../services/notes.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  note$!: Observable<Notes>;

  constructor(
    private _route: ActivatedRoute,
    private _notesService: NotesService
  ) {}

  ngOnInit(): void {
    this.getNoteById();
  }

  getNoteById() {
    const id = this._route.snapshot.paramMap.get('id');

    this.note$ = this._notesService.getNoteById(id);
  }
}
