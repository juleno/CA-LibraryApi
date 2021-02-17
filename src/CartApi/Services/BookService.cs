using Common.Models;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public async Task<decimal> GetBookPriceAsync(BookCommand bookCommand)
        {
            // get book stock
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");
                client.SendFrame(JsonConvert.SerializeObject(new Event<BookCommand> { EventType = EventType.Stock, Content = bookCommand }));
                var message = client.ReceiveFrameString();

                // le stock est suffisant pour cette quantité
                if (bool.Parse(message))
                {
                    client.SendFrame(JsonConvert.SerializeObject(new Event<BookCommand> { EventType = EventType.Price, Content = bookCommand }));
                    return decimal.Parse(client.ReceiveFrameString());
                }
                else
                {
                    throw new InvalidOperationException("Stock insuffisant");
                }
            }
        }


    }
}
