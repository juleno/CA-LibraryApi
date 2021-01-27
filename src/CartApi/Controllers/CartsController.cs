﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartApi.Data;
using CartApi.Models;
using CartApi.Services;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartApiContext _context;
        private BookService bookService;

        public CartsController(CartApiContext context)
        {
            _context = context;
            bookService = new BookService();
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Cart.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            decimal totalPrice = 0;
            Cart newCart = new Cart();
            foreach (var article in cart.Articles)
            {
                var book = await bookService.GetBookAsync(article.Book.Id);
                book.Author = null;
                newCart.Articles.Add(new Article { Book = book, Quantity = article.Quantity });
                totalPrice += article.Quantity * book.Price;
            }
            newCart.TotalPrice = totalPrice;
            foreach (var article in newCart.Articles)
            {
                _context.Entry(article.Book).State = EntityState.Unchanged;
            }
            _context.Cart.Add(newCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = newCart.Id }, newCart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.Id == id);
        }
    }
}