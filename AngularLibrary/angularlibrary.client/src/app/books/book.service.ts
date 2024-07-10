import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { BookModel } from "./book";

@Injectable()
export class BookService {

  private url = 'http://localhost:5246/api/books';
  constructor(private http: HttpClient) { }

  getBooks() {
    return this.http.get<Array<BookModel>>(this.url);
  }

  createBook(book: BookModel) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.post<BookModel>(this.url, JSON.stringify(book), { headers: myHeaders });
  }

  updateBook(book: BookModel) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.put<BookModel>(this.url, JSON.stringify(book), { headers: myHeaders });
  }

  deleteBook(id: number) {
    return this.http.delete<BookModel>(this.url + "/" + id);
  }
}
