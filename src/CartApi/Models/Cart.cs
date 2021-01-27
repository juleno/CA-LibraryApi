using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Cart()
        {
            Articles = new Collection<Article>();
        }
    }
}
