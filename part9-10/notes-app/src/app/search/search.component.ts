import { Component, EventEmitter, OnChanges, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit{

  word:string;

  @Output() emitSelectedWord = new EventEmitter<string>();

  constructor() { }

  selectWord(word: string) {
    this.emitSelectedWord.emit(word);
    console.log(word);
  }

  ngOnInit(): void {
  }

}
