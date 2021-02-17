using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CartApi.Models
{
    [DataContract]
    public class Cart
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "totalPrice")]
        public decimal TotalPrice { get; set; }

        [DataMember(Name = "articles")]
        public ICollection<Article> Articles { get; set; }

        public Cart()
        {
            Articles = new Collection<Article>();
        }
    }
}
