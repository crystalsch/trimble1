import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../category';
import { Note } from '../note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss']
})
export class EditNoteComponent implements OnInit {

  noteId: string
  title: string
  description: string
  categories: Category[]
  type: string;

  note: Note;

  constructor(private noteService: NoteService, private _activatedRoute: ActivatedRoute) { }

  receiveNoteId(noteId: string) {
    this.noteId = noteId;
  }


  public editNote() {
    const note: Note = {
      id: this.note.id,
      title: this.note.title,
      description: this.note.description,
      categoryId: this.note.categoryId
    }
    console.log(this.type)
    this.noteService.editNote(note).subscribe(res => console.log(res));
  }

  ngOnInit(): void {
    this.noteId = this._activatedRoute.snapshot.paramMap.get('id');
    this.noteService.getNote(this.noteId).subscribe(selectedNote => { this.note = selectedNote });
    this.categories = this.noteService.getCategory();
  }
}
