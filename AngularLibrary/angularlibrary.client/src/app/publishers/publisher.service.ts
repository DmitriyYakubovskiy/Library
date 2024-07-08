import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { PublisherModel } from "./publisher";

@Injectable()
export class PublisherService {

  private url = 'http://localhost:5246/api/publishers/';
  constructor(private http: HttpClient) { }

  getPublishers() {
    return this.http.get<Array<PublisherModel>>(this.url);
  }

  createPublisher(publisher: PublisherModel) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.post<PublisherModel>(this.url, JSON.stringify(publisher), { headers: myHeaders });
  }

  updatePublisher(publisher: PublisherModel) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.put<PublisherModel>(this.url, JSON.stringify(publisher), { headers: myHeaders });
  }

  deletePublisher(id: number) {

    return this.http.delete<PublisherModel>(this.url + "/" + id);
  }
}
