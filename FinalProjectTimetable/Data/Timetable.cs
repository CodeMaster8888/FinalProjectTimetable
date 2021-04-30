using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Timetable
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public string TimetableItems { get; set; }
    }
}
