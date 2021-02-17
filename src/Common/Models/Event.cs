using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Models
{
    [DataContract]
    public class Event<T>
    {
        [DataMember(Name = "eventType")]
        public EventType EventType { get; set; }

        [DataMember(Name = "content")]
        public T Content { get; set; }
    }

    public enum EventType
    {
        None = 0,
        Stock = 1,
        Price = 2
    }
}
