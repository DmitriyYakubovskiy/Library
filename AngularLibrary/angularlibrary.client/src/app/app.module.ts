import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './root-app/app.component';
import { NotFoundComponent } from './not-found/not-found.component';

import { PublisherService } from './publishers/publisher.service';
import { AuthorService } from './authors/author.service';
import { BookService } from './books/book.service';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NgIf, NgTemplateOutlet} from '@angular/common';

// определение маршрутов
const appRoutes: Routes = [
  { path: '', component: AppComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    NgIf,
    NgTemplateOutlet,
    RouterModule.forRoot(appRoutes),
  ],
  declarations: [
    AppComponent,
    NotFoundComponent,
  ],
  providers: [ BookService, AuthorService, PublisherService ,provideAnimationsAsync()], // регистрация сервисов
  bootstrap: [AppComponent],
})
export class AppModule {}
