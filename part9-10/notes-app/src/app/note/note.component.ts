import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Note } from '../note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent implements OnInit, OnChanges {

  notes: Note[];

  @Input() selectedCategoryId: string;
  @Input() selectedWord: string;

  constructor(
    private noteService: NoteService
  ) { }
  ngOnChanges(changes: SimpleChanges): void {
    this.noteService.getFilteredNotes(this.selectedCategoryId).subscribe((notes:Note[])=>{this.notes=notes})

  }

  ngOnInit(): void {
    this.noteService.getNotes().subscribe((notes:Note[])=>{this.notes=notes})
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
