using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CartApi.Models;
using Common.Models;

namespace CartApi.Data
{
    public class CartApiContext : DbContext
    {
        public CartApiContext (DbContextOptions<CartApiContext> options)
            : base(options)
        {
        }

        public DbSet<CartApi.Models.Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(5, 2);
            modelBuilder.Entity<Cart>().Property(b => b.TotalPrice).HasPrecision(5, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
