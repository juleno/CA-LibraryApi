export class Article {
    id: number;
    bookId: number;
    quantity: number;

    constructor(id: number, bookId: number, quantity: number) {
        this.id = id;
        this.bookId = bookId;
        this.quantity = quantity;
    }
}