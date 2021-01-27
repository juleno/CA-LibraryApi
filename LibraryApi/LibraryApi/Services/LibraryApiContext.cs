using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryApi.Models;

namespace LibraryApi.Services
{
    public class LibraryApiContext : DbContext
    {
        public LibraryApiContext (DbContextOptions<LibraryApiContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryApi.Models.Book> Book { get; set; }

    }
}
