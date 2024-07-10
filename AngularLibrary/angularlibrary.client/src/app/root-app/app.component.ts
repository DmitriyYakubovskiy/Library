import { Component, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { BookModel } from "../books/book";
import { PublisherModel } from '../publishers/publisher';
import { AuthorModel } from '../authors/author';
import { AuthorService } from '../authors/author.service'
import { PublisherService } from '../publishers/publisher.service'
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
  authors: Array<AuthorModel>;
  publishers: Array<PublisherModel>;
  isNewRecord: boolean = false;
  statusMessage: string = "";

  AuthorChanged(e) {
    this.editedBook.author = this.authors[e.target.value-1]
  }

  PublisherChanged(e) {
    this.editedBook.publisher = this.publishers[e.target.value-1]
  }

  constructor(private bookService: BookService, private authorService: AuthorService, private publisherService: PublisherService) {
    this.books = new Array<BookModel>();
    this.authors = new Array<AuthorModel>();
    this.publishers = new Array<PublisherModel>();
  }

  ngOnInit() {
    this.loadPublishers();
    this.loadAuthors();
    this.loadBooks();
  }

  private loadPublishers() {
    this.publisherService.getPublishers().subscribe((data: Array<PublisherModel>) => {
      this.publishers = data;
    })
  }

  private loadAuthors() {
    this.authorService.getAuthors().subscribe((data: Array<AuthorModel>) => {
      this.authors = data;
    });
  }

  private loadBooks() {
    this.bookService.getBooks().subscribe((data: Array<BookModel>) => {
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
    if (this.editedBook && this.editedBook.id === book.id) {
      return this.editTemplate;
    } else {
      return this.readOnlyTemplate;
    }
  }

  saveBook() {
    if (this.isNewRecord) {
      this.bookService.createBook(this.editedBook as BookModel).subscribe(_ => {
        this.statusMessage = "Данные успешно добавлены",
          this.loadBooks();
      });
      this.isNewRecord = false;
      this.editedBook = null;
    } else {
      this.bookService.updateBook(this.editedBook as BookModel).subscribe(_ => {
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
    this.bookService.deleteBook(book.id).subscribe(_ => {
      this.statusMessage = "Данные успешно удалены",
        this.loadBooks();
    });
  }
}
