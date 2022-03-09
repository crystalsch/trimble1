import { Component, OnInit } from '@angular/core';
import {Category} from '../category'

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories:Category[]=[
    {name:'To Do', id:'1'},
    {name:'Done', id:'2'},
    {name:'To Do', id:'2'}
  ]

  constructor() { }

  ngOnInit(): void {
  }

}
