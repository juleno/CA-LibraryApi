using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontLibrary.Services
{
    public class BookService
    {
        private HttpClient client { get; set; }
        private string apiBook = "http://localhost:58521/api/Books";

        public BookService()
        {
            client = new HttpClient();
        }

        public async Task<List<Book>> GetAllBook()
        {
            var response = await client.GetAsync(apiBook);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Book>>(result);
        }
    }
}
