import { Component, OnInit } from '@angular/core';
import { Category } from '../category';
import { Note } from '../note';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {

  title: string
  description: string
  categories: Category[]
  type: string

  constructor(private noteService: NoteService) { }

  public addNote() {
    const note: Note = {
      title: this.title,
      description: this.description,
      categoryId: this.type 
    }
    console.log(this.type)
    this.noteService.addNote(note).subscribe();
    
  }

  ngOnInit(): void {
    this.categories = this.noteService.getCategory();
  }

  // public ngOnDestroy(): void {
  //   this.noteService.addNotes(this.title, this.description,this.type);
  // }

}
