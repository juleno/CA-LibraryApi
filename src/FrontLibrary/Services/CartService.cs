using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrontLibrary.Services
{
    public class CartService
    {
        private HttpClient client { get; set; }
        private string apiCart = "http://localhost:63934/api/Carts";

        public CartService()
        {
            client = new HttpClient();
        }

        public async Task<Cart> PostCart(Cart cart)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiCart, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Cart>(result);
        }
    }
}
