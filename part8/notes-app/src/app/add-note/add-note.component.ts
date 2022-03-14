import { Component, OnInit } from '@angular/core';
import { Category } from '../category';
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
  type:string

  constructor(private noteService: NoteService) { }

  ngOnInit(): void {
    this.noteService.serviceCall();
    this.categories = this.noteService.getCategory();
  }
  public ngOnDestroy(): void {
    this.noteService.addNotes(this.title, this.description,this.type);
  }

}
