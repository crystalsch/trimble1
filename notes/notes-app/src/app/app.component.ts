import { Component, HostListener } from '@angular/core';
import { Data } from '@angular/router';

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
  fruits: string[] = ['Apple', 'Orange', 'Banana'];
  dates: Date[] = [new Date(5,6,2005), new Date(29,5,2006), new Date(18,11,2007)];
  myColor:string="Pink"
  inter:string=""
}
