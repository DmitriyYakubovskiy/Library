import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AuthorModel } from "./author";

@Injectable()
export class AuthorService {

  private url = 'http://localhost:5246/api/authors/';
  constructor(private http: HttpClient) { }

  getAuthors() {
    return this.http.get<Array<AuthorModel>>(this.url);
  }

  createAuthor(author: AuthorModel) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.post<AuthorModel>(this.url, JSON.stringify(author), { headers: myHeaders });
  }

  updateAuthor(author: AuthorModel) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.put<AuthorModel>(this.url, JSON.stringify(author), { headers: myHeaders });
  }

  deleteAuthor(id: number) {

    return this.http.delete<AuthorModel>(this.url + "/" + id);
  }
}
