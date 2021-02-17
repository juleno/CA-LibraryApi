using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Models
{
    [DataContract]
    public class Book
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "publicationDate")]
        public DateTime PublicationDate { get; set; }

        [DataMember(Name = "author")]
        public Author Author { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "stock")]
        public int Stock { get; set; }
    }
}