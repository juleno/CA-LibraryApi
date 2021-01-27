using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartApi.Models
{
    public class Article
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}