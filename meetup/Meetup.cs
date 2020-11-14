using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly IEnumerable<DateTime> _dates;
    public Meetup(int month, int year)
    {
        _dates = AllDatesInMonth(year, month);
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        switch (schedule)
        {
            case Schedule.First:
                return _dates.Where(d => d.DayOfWeek == dayOfWeek).First();
            case Schedule.Second:
                return _dates.Where(d => d.DayOfWeek == dayOfWeek).ToList()[1];
            case Schedule.Third:
                return _dates.Where(d => d.DayOfWeek == dayOfWeek).ToList()[2];
            case Schedule.Fourth:
                return _dates.Where(d => d.DayOfWeek == dayOfWeek).ToList()[3];
            case Schedule.Last:
                return _dates.Where(d => d.DayOfWeek == dayOfWeek).Last();
            case Schedule.Teenth:
                return _dates.Where(d => d.Day > 12 && d.Day < 20 && d.DayOfWeek == dayOfWeek).First();
            default:
                return _dates.ToList()[0];
        }
    }

    private static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
    {
        var days = DateTime.DaysInMonth(year, month);
        for (int day = 1; day <= days; day++)
        {
            yield return new DateTime(year, month, day);
        }
    }
}