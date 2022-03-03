import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { W2Module } from './w2/w2.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    W2Module
  ],
  exports:[
    W2Module
  ]
})
export class W1Module { }
