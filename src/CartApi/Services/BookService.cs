using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CartApi.Services
{
    public class BookService
    {
        public string BookApiUrl { get; set; }
        public HttpClient Client { get; set; }

        public BookService()
        {
            BookApiUrl = "http://localhost:58521/api/Books";
            Client = new HttpClient();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var result = Client.GetAsync(BookApiUrl + "/" + id);
            HttpResponseMessage response = await Client.GetAsync(BookApiUrl + "/" + id);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Book>(responseBody);
        }

    }
}
