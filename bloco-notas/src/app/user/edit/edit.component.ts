import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Notes } from 'src/app/models/notes.model';
import { NotesService } from '../services/notes.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
})
export class EditComponent implements OnInit {
  note!: Notes;
  form: FormGroup;
  constructor(
    public dialogRef: MatDialogRef<EditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Notes,
    private _fb: FormBuilder,
    private _notesService: NotesService
  ) {}

  ngOnInit(): void {
    this.note = this.data;

    this.startForm();
  }

  startForm() {
    this.form = this._fb.group({
      title: [
        this.data?.title,
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(100),
        ],
      ],
      content: [this.data?.content, [Validators.maxLength(1000)]],
    });
  }

  saveChanges() {
    const note: Notes = {
      id: this.data.id,
      title: this.form.value.title,
      content: this.form.value.content,
      isFiled: this.data.isFiled,
      userId: this.data.userId,
    };

    console.log(note);

    this._notesService.editNote(note).subscribe({
      error: (err) => console.log('deu ruim'),
      next: () => console.log('deu bom'),
    });
  }

  cancel() {
    this.dialogRef.close();
  }
}
