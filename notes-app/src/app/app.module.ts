import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { App2Component } from './app2/app2.component';
import { Ex1Module } from './ex1/ex1.module';
import { Ex2Module } from './ex2/ex2.module';

@NgModule({
  declarations: [
    AppComponent,
    App2Component,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    Ex1Module,
    Ex2Module
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
