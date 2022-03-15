import { Component, OnChanges, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit{

  par: string
  categoryId: string;
  word: string;

  constructor() { }

  receiveCategory(categId: string) {
    this.categoryId = categId;
  }

  receiveWord(wordr: string) {
    this.word = wordr;
  }

  ngOnInit(): void {
  }


}
