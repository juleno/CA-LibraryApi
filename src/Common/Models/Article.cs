using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Models
{
    [DataContract]
    public class Article
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "cart")]
        public Cart Cart { get; set; }

        [DataMember(Name = "bookId")]
        public int BookId { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
    }
}