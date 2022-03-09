import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'notes-app';
  text:string="test"
  dateTest: Date=new Date(5,6,2002)
  myValue:number=10
}
