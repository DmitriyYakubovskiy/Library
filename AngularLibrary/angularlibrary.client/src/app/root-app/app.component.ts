import { Component, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { BookModel } from "../books/book";
import { PublisherModel } from '../publishers/publisher';
import { AuthorModel } from '../authors/author';
import { BookService } from '../books/book.service';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  providers: [BookService]
})

export class AppComponent implements OnInit {

  @ViewChild("readOnlyTemplate", { static: false }) readOnlyTemplate: TemplateRef<any>|undefined;
  @ViewChild("editTemplate", { static: false }) editTemplate: TemplateRef<any>|undefined;

  editedBook: BookModel|null = null;
  books: Array<BookModel>;
  isNewRecord: boolean = false;
  statusMessage: string = "";

  constructor(private serv: BookService) {
    this.books = new Array<BookModel>();
  }

  ngOnInit() {
    this.loadBooks();
  }

  private loadBooks() {
    this.serv.getBooks().subscribe((data: Array<BookModel>) => {
      this.books = data;
    });
  }

  addBook() {
    this.editedBook = new BookModel(0,"", "", 0);
    this.books.push(this.editedBook);
    this.isNewRecord = true;
  }

  editBook(book: BookModel) {
    this.editedBook = new BookModel(book.id, book.name, book.genre, book.year, book.author, book.publisher);
  }

  loadTemplate(book: BookModel) {
    if (this.editBook === null) return this.readOnlyTemplate;
    if (this.editedBook && this.editedBook.id === book.id) {
      return this.editTemplate;
    } else {
      return this.readOnlyTemplate;
    }
  }

  saveBook() {
    if (this.isNewRecord) {
      this.serv.createBook(this.editedBook as BookModel).subscribe(_ => {
        this.statusMessage = "Данные успешно добавлены",
          this.loadBooks();
      });
      this.isNewRecord = false;
      this.editedBook = null;
    } else {
      this.serv.updateBook(this.editedBook as BookModel).subscribe(_ => {
        this.statusMessage = "Данные успешно обновлены",
          this.loadBooks();
      });
      this.editedBook = null;
    }
  }

  cancel() {
    if (this.isNewRecord) {
      this.books.pop();
      this.isNewRecord = false;
    }
    this.editedBook = null;
  }

  deleteBook(book: BookModel) {
    this.serv.deleteBook(book.id).subscribe(_ => {
      this.statusMessage = "Данные успешно удалены",
        this.loadBooks();
    });
  }
}
