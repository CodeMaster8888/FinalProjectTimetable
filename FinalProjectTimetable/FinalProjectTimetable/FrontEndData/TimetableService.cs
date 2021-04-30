using Data;
using Services;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace FinalProjectTimetable.FrontEndData
{
    public class TimetableService
    {
        private readonly ITimetableManager _timetableManager;

        public TimetableService(ITimetableManager timetableManager)
        {
            _timetableManager = timetableManager ?? 
                throw new ArgumentNullException(nameof(timetableManager));
        }

        public string GetTimetableView(int userId)
        {
            var timetable = _timetableManager.GetTimetable(userId);

            if(timetable == null)
            {
                return null;
            }

            return _timetableManager.ConvertTimetable(timetable);
        }

        public void AddDate(TimetableItem timetableItem, int userId)
        {
            var frontEndtimetable = MapToFrontEndTimetable(_timetableManager.GetTimetable(userId));

            if (frontEndtimetable == null)
            {
                frontEndtimetable = new Timetable
                {
                    UserId = userId
                };
            }

            frontEndtimetable.TimetableItems.Add(timetableItem);

            var timetable = MapToTimetable(frontEndtimetable);

            _timetableManager.AddTimetableSchedule(timetable); 
        }

        public void AddSchedule(TimetableParameters parameters, int userId)
        {
            var frontEndtimetable = MapToFrontEndTimetable(_timetableManager.GetTimetable(userId));

            if (frontEndtimetable == null)
            {
                frontEndtimetable = new Timetable
                {
                    UserId = userId
                };
            }

            var totalDays = parameters.EndDate.CompareTo(parameters.StartDate);

            if (parameters.IsEveryDay || parameters.IsEveryOtherDay)
            {
                CreateDaySchedule(parameters, frontEndtimetable, totalDays);
            }else if (parameters.TotalHours > 0)
            {
                CreateHourSchedule(parameters, frontEndtimetable, totalDays);
            }

            var timetable = MapToTimetable(frontEndtimetable);

            _timetableManager.AddTimetableSchedule(timetable);
        }

        private void CreateHourSchedule(TimetableParameters parameters, Timetable timetable, int totalDays)
        {
            var daySpread = totalDays / parameters.TotalHours;

            for (int i = 0; i < totalDays; i+=daySpread)
            {
                timetable.TimetableItems.Add(new TimetableItem
                {
                    Id = new Guid(),
                    Name = parameters.Name,
                    StartDate = parameters.StartDate.AddDays(i),
                    EndDate = parameters.StartDate.AddDays(i).AddHours(1)
                });
            }
        }

        private void CreateDaySchedule(TimetableParameters parameters, Timetable timetable, int totalDays)
        {
            if (parameters.IsEveryDay)
            {
                for (int i = 0; i < totalDays; i++)
                {
                    timetable.TimetableItems.Add(new TimetableItem
                    {
                        Id = new Guid(),
                        Name = parameters.Name,
                        StartDate = parameters.StartDate.AddDays(i)
                    });
                }
            }
            else
            {
                for (int i = 0; i < totalDays; i += 2)
                {
                    timetable.TimetableItems.Add(new TimetableItem
                    {
                        Id = new Guid(),
                        Name = parameters.Name,
                        StartDate = parameters.StartDate.AddDays(i)
                    });
                }
            }
        }

        private Data.Timetable MapToTimetable(Timetable timetable)
        {
            var mapppedTimetable = new Data.Timetable
            {
                TimetableItems = JsonSerializer.Serialize(timetable.TimetableItems),
                UserId = timetable.UserId,
                Id = timetable.Id
            };

            return mapppedTimetable;
        }

        private Timetable MapToFrontEndTimetable(Data.Timetable timetable)
        {
            var mapppedTimetable = new Timetable
            {
                TimetableItems = JsonSerializer.Deserialize<List<TimetableItem>>(timetable.TimetableItems),
                UserId = timetable.UserId,
                Id = timetable.Id
            };

            return mapppedTimetable;
        }
    }
}
