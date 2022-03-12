import { Component, OnInit } from '@angular/core';
import {Category} from '../category'
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories:Category[]

  constructor(private noteService: NoteService) { }

  ngOnInit(): void {
    this.noteService.serviceCall();
    this.categories=this.noteService.getCategory();
  }

}
