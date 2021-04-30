using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CalenderEvent
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
    }
}
