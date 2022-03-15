import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit {

  color:string= "";
  bckColor:string ="";
  constructor() { }

  ngOnInit(): void {
  }
  setColor() { this.bckColor = this.color; }
}
