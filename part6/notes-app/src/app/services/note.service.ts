import { ReturnStatement } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Category } from '../category';
import { Note } from '../note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {


  notes: Note[] = [
    {
      id: "Id1",
      title: "First note",
      description: "This is the description for the first note"
    },
    {
      id: "Id2",
      title: "Second note",
      description: "This is the description for the second note"
    },
    {
      id: "Id3",
      title: "Third note",
      description: "This is the description for the third note"
    }
  ];

  categories: Category[] = [
    { name: 'To Do', id: '1' },
    { name: 'Done', id: '2' },
    { name: 'Doing', id: '3' }
  ]

  constructor() { }

  serviceCall() {
    console.log("Note service was called");
  }

  getNotes() {
    return this.notes;
  }

  addNotes(title: string, description: string) {
    let x: Note
    x.id = 'id3'
    x.title = title;
    x.description = description;
    this.notes.push(x);
  }
  
  getCategory() {
    return this.categories;
  }

}
