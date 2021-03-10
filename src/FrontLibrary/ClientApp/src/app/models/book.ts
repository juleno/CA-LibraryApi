import { Author } from "./author";

export class Book {
  id: number;
  title: string;
  publicationDate: Date;
  author: Author;
  price: number;
  stock: number;
  quantity: number;
}
