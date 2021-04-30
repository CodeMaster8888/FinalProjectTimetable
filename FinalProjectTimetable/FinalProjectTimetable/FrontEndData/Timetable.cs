using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectTimetable.FrontEndData
{
    public class Timetable
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public List<TimetableItem> TimetableItems { get; set; }
    }
}
