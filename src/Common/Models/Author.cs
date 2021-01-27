using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}