import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Note } from '../note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnChanges {

  notes: Note[];
  note: Note;

  @Output() emitSelectedNote = new EventEmitter<string>();
  @Input() selectedCategoryId: string;
  @Input() selectedNote: string;
  @Input() selectedWord: string;

  constructor(
    private noteService: NoteService
  ) { }

  selectFilter(noteId: string) {
    this.emitSelectedNote.emit(noteId);
    console.log(noteId);
  }

  selectId(noteId: string) {
    this.emitSelectedNote.emit(noteId);
    console.log(noteId);
  }

  getId(id: string) {
    console.log(id);
    this.noteService.deleteNote(id).subscribe();
    this.noteService.getNotes().subscribe((note) => {
      this.notes = note;
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.noteService.getFilteredNotes(this.selectedCategoryId).subscribe((notes: Note[]) => { this.notes = notes })
    this.noteService.getSpecificNotes(this.selectedWord).subscribe((notes: Note[]) => { this.notes = notes });
  }

  ngOnInit(): void {
    const allNotes = this.noteService.getNotes().subscribe((notes: Note[]) => {
      this.notes = notes
    });
  }



  // ngOnInit(): void {
  //   this.noteService.serviceCall();
  //   this.notes = this.noteService.getNotes();
  // }

  // ngOnChanges(): void {
  //   this.notes = this.noteService.getFiltredNotes(this.selectedCategoryId);
  //   this.notes = this.noteService.getSpecificNotes(this.selectedWord);
  // }



}
