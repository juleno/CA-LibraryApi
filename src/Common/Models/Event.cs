using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Event
    {
        public EventType EventType { get; set; }
        public BookCommand Content { get; set; }
    }

    public enum EventType
    {
        Stock,
        Price
    }
}
