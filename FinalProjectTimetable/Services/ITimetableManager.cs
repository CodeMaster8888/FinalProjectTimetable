using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ITimetableManager
    {
        void AddTimetableSchedule(Timetable timetable);
        string ConvertTimetable(Timetable timetable);
        Timetable GetTimetable(int userId);
    }
}
