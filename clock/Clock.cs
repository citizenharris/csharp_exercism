using System;

public class Clock
{
    private readonly int _timeInMinutes;
    public int Hours => _timeInMinutes / 60;
    public int Minutes => _timeInMinutes % 60;

    public Clock(int hours, int min)
    {
        _timeInMinutes = ToTimeInMinutes(hours * 60 + min);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, _timeInMinutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(0, _timeInMinutes - minutesToSubtract);
    }

    public override string ToString() => $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";

    public override int GetHashCode() => Hours.GetHashCode() + Minutes.GetHashCode();

    public bool Equals(Clock expected) => Hours == expected.Hours && Minutes == expected.Minutes;

    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !GetType().Equals(obj.GetType()))
            return false;
        else
        {
            Clock c = (Clock)obj;
            return (Hours == c.Hours) && (Minutes == c.Minutes);
        }
    }

    private int ToTimeInMinutes(int minutes)
    {
        var minutesInDay = 24 * 60;
        var min = minutes % minutesInDay;
        var adjustedMinutes = min + minutesInDay;
        return adjustedMinutes % minutesInDay;
    }
}