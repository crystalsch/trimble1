import { Component, OnInit } from '@angular/core';
import { Category } from '../category'
import { NoteService } from '../services/note.service';
import { EventEmitter, Output } from "@angular/core";

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  @Output() emitSelectedFilter = new EventEmitter<string>();


  categories: Category[]

  constructor(private noteService: NoteService) { }

  selectFilter(categoryId: string) {
    this.emitSelectedFilter.emit(categoryId);
    console.log(categoryId);
  }


  ngOnInit(): void {
    this.noteService.serviceCall();
    this.categories = this.noteService.getCategory();
  }

}
