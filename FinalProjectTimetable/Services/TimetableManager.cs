using Data;
using Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class TimetableManager : ITimetableManager
    {
        private readonly ITimetableItemContext _timetableItemContext;
        public TimetableManager(ITimetableItemContext timetableItemContext)
        {
            _timetableItemContext = timetableItemContext ?? 
                throw new ArgumentNullException(nameof(timetableItemContext));
        }

        public Timetable GetTimetable(int userId)
        {
            var timetable = _timetableItemContext.GetTimetable(userId);

            return timetable;
        }

        public void AddTimetableSchedule(Timetable timetable)
        {
            _timetableItemContext.AddTimetableItem(timetable);
        }

        public string ConvertTimetable(Timetable timetable)
        {
            List<CalenderEvent> calender = new List<CalenderEvent>();

            var timetableItems = JsonSerializer.Deserialize<List<TimetableItems>>(timetable.TimetableItems);

            foreach (var item in timetableItems)
            {
                calender.Add(new CalenderEvent 
                {
                    start = item.StartDate,
                    end = item.EndDate,
                    title = item.Name,
                    id = item.Id
                });
            }

            var jsonCalender = JsonSerializer.Serialize(calender);

            return jsonCalender;
        }
    }
}
