using Common.Models;
using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApi.Services
{
    public class QueueListenerService : BackgroundService
    {
        private readonly ILogger<QueueListenerService> _serviceLogger;
        private readonly LibraryApiContext _context;

        public QueueListenerService(ILogger<QueueListenerService> serviceLogger, LibraryApiContext libraryApiContext)
        {
            _serviceLogger = serviceLogger;
            _context = libraryApiContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() => _serviceLogger.LogDebug("Queue service is stopping."));
            var responder = new ResponseSocket();
            responder.Bind("tcp://*:5555");
            string str;
            while (!stoppingToken.IsCancellationRequested)
            {
                if(responder.TryReceiveFrameString(out str))
                {
                    Console.WriteLine("Received event");
                    responder.SendFrame(ProcessEvent(JsonConvert.DeserializeObject<Event<BookCommand>>(str)));
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        private string ProcessEvent(Event<BookCommand> evnt) 
        {
            string result = "";
            var book = _context.Book.FirstOrDefault(b => b.Id == evnt.Content.BookId);

            switch (evnt.EventType)
            {
                case EventType.Stock:
                    
                    if (book.Stock - evnt.Content.Quantity >= 0)
                    {
                        _context.Entry(book).State = EntityState.Modified;
                        book.Stock -= evnt.Content.Quantity;
                        _context.SaveChangesAsync();

                        return "true";
                    }

                    return "false";

                case EventType.Price:

                    return (book.Price * evnt.Content.Quantity).ToString();
            }

            return result;
        }
    }
}
