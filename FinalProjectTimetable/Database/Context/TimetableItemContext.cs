using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Context
{
    public class TimetableItemContext : ITimetableItemContext
    {
        private readonly TimetableContext _context;

        public TimetableItemContext(TimetableContext timetableContext)
        {
            _context = timetableContext ?? throw new ArgumentNullException(nameof(timetableContext));
        }

        public Timetable GetTimetable(int userId)
        {
            var test = _context.Timetable.SingleOrDefault(x => x.UserId == userId);

            return test;
        }

        public void AddTimetableItem(Timetable timetable)
        {
            _context.Timetable.Add(timetable);
            _context.SaveChanges();
        }
    }
}
