import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cart } from '../models/cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  cartUrl = 'api/cart';

  constructor(private http: HttpClient) { }

  postCommand(cart: Cart) {
    return this.http.post<Cart>(this.cartUrl, cart);
  }
}
