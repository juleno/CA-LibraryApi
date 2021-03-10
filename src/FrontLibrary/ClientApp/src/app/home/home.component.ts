import { Component, OnInit } from '@angular/core';
import { Article } from '../models/article';
import { Book } from '../models/book';
import { Cart } from '../models/cart';
import { BookService } from '../services/book.service';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  cart: Cart = new Cart();
  books: Book[];
  totalPrice: number = 0;

  constructor(private bookService: BookService, private cartService: CartService) {
  }

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks(): void {
    this.bookService.getBooks().subscribe((data: Book[]) => {
      this.books = data;
      this.books.forEach(b => b.quantity = 0);
    });
  }

  addToCart(book: Book) {
    this.cart.books.push(book);
  }

  validate(): void {
    this.cart.books.forEach(b => {
      this.cart.articles.push(new Article(0, b.id, b.quantity));
    });
    this.cartService.postCommand(this.cart).subscribe((data: Cart) => {
      this.totalPrice = data.totalPrice;
    });
  }
}
