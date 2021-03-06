import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatButtonModule } from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from "@angular/material/card";


import { AppComponent } from './app.component';
import { NoteComponent } from './note/note.component';
import { ToolsComponent } from './tools/tools.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddValuePipe } from './add-value.pipe';
import { FilterComponent } from './filter/filter.component';
import { ChangeColorPipe } from './change-color.pipe';
import { DirDirective } from './dir.directive';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NoteComponent,
    ToolsComponent,
    AddValuePipe,
    FilterComponent,
    ChangeColorPipe,
    DirDirective
  ],
  imports: [
    BrowserModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    MatCardModule,
    AppRoutingModule
  ],
  providers: [DirDirective],
  bootstrap: [AppComponent]
})
export class AppModule {}
