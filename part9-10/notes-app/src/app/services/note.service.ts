import { animate } from '@angular/animations';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { outputAst, ReturnStatement } from '@angular/compiler';
import { Injectable, Output } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Category } from '../category';
import { Note } from '../note';

@Injectable({
  providedIn: 'root',

})
export class NoteService {


  // notes: Note[] = [
  //   {
  //     id: "Id1",
  //     title: "First note",
  //     description: "This is the description for the first note",
  //     category: '1'
  //   },
  //   {
  //     id: "Id2",
  //     title: "Second note",
  //     description: "This is the description for the second note",
  //     category: '2'
  //   },
  //   {
  //     id: "Id3",
  //     title: "Third note",
  //     description: "This is the description for the third note",
  //     category: '3'
  //   }
  // ];

  categories: Category[] = [
    { name: 'To Do', id: '1' },
    { name: 'Done', id: '2' },
    { name: 'Doing', id: '3' }
  ]

  readonly baseUrl = "https://localhost:4200";

  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };


  constructor(private httpClient: HttpClient) { }

  getFilteredNotes(categoryId: string): Observable<Note[]> {
    return this.httpClient
      .get<Note[]>(
        this.baseUrl + `/notes`,
        this.httpOptions
      )
      .pipe(
        map((notes: Note[]) => { return notes.filter((note) => note.categoryId === categoryId) })
      );
  }

  getSpecificNotes(word: string): Observable<Note[]> {
    return this.httpClient
      .get<Note[]>(
        this.baseUrl + `/notes`,
        this.httpOptions
      )
      .pipe(
        map((notes: Note[]) => { return notes.filter((note) => note.title.includes(word) || note.description.includes(word)) })
      );
  }

  addNote(note: Note) {
    return this.httpClient.post(this.baseUrl + "/notes", note, this.httpOptions);
  }

  editNote(note: Note) {
    return this.httpClient.put(this.baseUrl + "/notes"+ note.id, note, this.httpOptions);
  }

  getNotes(): Observable<Note[]> {
    return this.httpClient.get<Note[]>(this.baseUrl + `/notes`, this.httpOptions);
  }

  getNote(noteId:string): Observable<Note> {
    return this.httpClient.get<Note>(this.baseUrl + `/notes/` + noteId, this.httpOptions);
  }

  deleteNote(noteId: string): Observable<Note> {
    let idUrl = '/notes/' + noteId;
    return this.httpClient.delete<Note>(this.baseUrl + idUrl);
  }

  serviceCall() {
    console.log("Note service was called");
  }

  getCategory() {
    return this.categories;
  }

  // getNotes() {
  //   return this.notes;
  // }

  // addNotes(title: string, description: string, type: string) {
  //   let x: Note = {
  //     title: title, description: description,
  //     id: '', category: type
  //   }
  //   console.log(x.title, x.description);
  //   this.notes.push(x);
  // }


  // getFiltredNotes(categoryId: string) {
  //   return this.notes.filter(nota=> nota.category === categoryId);
  // }


  // getSpecificNotes(word: string) {
  //   return this.notes.filter(nota=> nota.title.includes(word) || nota.description.includes(word));
  // }

}
