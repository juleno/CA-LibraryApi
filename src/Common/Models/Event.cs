using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Event<T>
    {
        public EventType EventType { get; set; }
        public T Content { get; set; }
    }

    public enum EventType
    {
        Stock,
        Price
    }
}
