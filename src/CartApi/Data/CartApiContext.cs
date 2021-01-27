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
            modelBuilder.Entity<Cart>().Property(c => c.TotalPrice).HasPrecision(5, 2);
            modelBuilder.Entity<Article>().Property(a => a.BookId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
