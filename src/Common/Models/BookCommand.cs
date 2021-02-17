using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Models
{
    [DataContract]
    public class BookCommand
    {
        [DataMember(Name = "bookId")]
        public int BookId { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
    }
}
