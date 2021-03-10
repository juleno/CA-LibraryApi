import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  booksUrl = 'api/library';

  constructor(private http: HttpClient) { }

  getBooks() {
    return this.http.get<Book[]>(this.booksUrl);
  }
}
