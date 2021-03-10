import { Article } from "./article";
import { Book } from "./book";

export class Cart {
  id: number;
  books: Book[] = [];
  articles: Article[] = [];
  totalPrice: number;
}
