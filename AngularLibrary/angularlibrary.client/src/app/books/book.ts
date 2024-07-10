import { PublisherModel } from '../publishers/publisher';
import { AuthorModel } from '../authors/author';

export class BookModel {
  constructor(
    public id?: number,
    public name?: string,
    public genre?: string,
    public year?: number,
    public author?: AuthorModel,
    public publisher?: PublisherModel) { }
}
