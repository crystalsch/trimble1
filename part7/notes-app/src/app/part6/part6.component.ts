import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-part6',
  templateUrl: './part6.component.html',
  styleUrls: ['./part6.component.scss']
})
export class Part6Component implements OnInit {

  val: string

  constructor(private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.val = this._activatedRoute.snapshot.paramMap.get('id')
  }
}
