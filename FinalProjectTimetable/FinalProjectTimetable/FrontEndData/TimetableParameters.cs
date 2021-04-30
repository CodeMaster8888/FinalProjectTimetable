using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectTimetable.FrontEndData
{
    public class TimetableParameters
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public bool IsEveryDay { get; set; }
        public bool IsEveryOtherDay { get; set; }
        public bool IsWeekDay { get; set; }
        public bool IsWeekEnd { get; set; }
        public int TotalHours { get; set; }
    }
}
