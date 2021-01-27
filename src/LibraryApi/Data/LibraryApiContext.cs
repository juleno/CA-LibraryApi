using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Data
{
    public class LibraryApiContext : DbContext
    {
        public LibraryApiContext(DbContextOptions<LibraryApiContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(5, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
