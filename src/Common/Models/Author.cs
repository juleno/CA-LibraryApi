using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Common.Models
{
    [DataContract]
    public class Author
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }

        [DataMember(Name = "books")]
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new Collection<Book>();
        }
    }
}