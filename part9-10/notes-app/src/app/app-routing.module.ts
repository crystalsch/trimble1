import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { RouterModule, Routes } from "@angular/router";
import { AddNoteComponent } from './add-note/add-note.component';
import { Part6Component } from './part6/part6.component';
import { FilterComponent } from './filter/filter.component';
import { NoteComponent } from './note/note.component';
import { EditNoteComponent } from './edit-note/edit-note.component';


const appRoutes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "add-note", component: AddNoteComponent },
  { path: "app-part6/:id", component: Part6Component },
  { path: "app-filter", component: FilterComponent },
  { path: "app-note", component: NoteComponent },
  { path: "app-edit-note/:id", component: EditNoteComponent },
  { path: '**', redirectTo: '' }
]


@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

