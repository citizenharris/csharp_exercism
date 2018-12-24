using System;

public class Clock
{
    public Clock(int hours, int minutes)
    {
        Hours = minutes > 59 || minutes < 0?
            FormatHours(hours + FormatMinutesAdd(minutes).Item1) : FormatHours(hours);
        Minutes = FormatMinutesAdd(minutes).Item2;
    }

    public int Hours { get; private set; }
    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd)
    {
        Hours += FormatMinutesAdd(minutesToAdd).Item1;
        Minutes += FormatMinutesAdd(minutesToAdd).Item2;
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        Hours -= FormatMinutesSubtract(minutesToSubtract).Item1;
        Minutes -= FormatMinutesSubtract(minutesToSubtract).Item2;
        return this;
    }


    public override string ToString()
    {
        return $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";
    }

    private static int FormatHours(int hoursToAdd)
    {
        if (hoursToAdd < 0) return 24 - ((hoursToAdd * -1) % 24);
        return hoursToAdd >= 24 ? hoursToAdd % 24 : hoursToAdd;
    }

    private static void BreakDownMinutes(int minutesToAdd, out int hours, out int mins)
    {
        var asHours = ((double)minutesToAdd) / 60;
        var asHoursRounded = Math.Floor(asHours);
        mins = (int)Math.Ceiling(((asHours) - asHoursRounded) * 60);
        hours = (int)asHoursRounded;
    }

    private static Tuple<int, int> FormatMinutesAdd(int minutesToAdd)
    {
        if (minutesToAdd > 59)
        {
            BreakDownMinutes(minutesToAdd, out var hours, out var mins);
            return new Tuple<int, int>
                (FormatHours(hours), mins);
        }
        else if (minutesToAdd < 0)
        {
            minutesToAdd *= -1;
            BreakDownMinutes(minutesToAdd, out var hours, out var mins);
            return new Tuple<int, int>
                    ((FormatHours(hours * -1)), (60 - mins));
        } else
        {
            return new Tuple<int, int>(0, minutesToAdd);
        }
    }

    private Tuple<int, int> FormatMinutesSubtract(int minutesToSubtract)
    {
        if (minutesToSubtract > 59)
        {
            BreakDownMinutes(minutesToSubtract, out var hours, out var mins);
            return new Tuple<int, int>
                (FormatHours(hours), mins);
        }
        return new Tuple<int, int>(0, minutesToSubtract);
    }
}