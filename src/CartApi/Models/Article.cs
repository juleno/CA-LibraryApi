using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartApi.Models
{
    public class Article
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}