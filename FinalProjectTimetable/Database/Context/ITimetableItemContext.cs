using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Context
{
    public interface ITimetableItemContext
    {
        void AddTimetableItem(Timetable timetable);
        Timetable GetTimetable(int userId);
    }
}
