import { PublisherModel } from '../publishers/publisher';
import { AuthorModel } from '../authors/author';

export class BookModel {
  constructor(
    public id: number = 0,
    public name: string = "",
    public genre: string = "",
    public year: number= 0,
    public author?: AuthorModel,
    public publisher?: PublisherModel) { }
}
