import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { W1Module } from './w1/w1.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    W1Module
  ],
  exports:[
    W1Module
  ]
})
export class Ex2Module { }
