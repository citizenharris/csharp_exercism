using System;

public class Clock : IEquatable<Clock>
{
    public Clock(int hours, int minutes)
    {
        Hours = minutes > 59 || minutes < 0?
            FormatHours(hours + GetOverspillMinutes(minutes).Item1) : FormatHours(hours);
        Minutes = minutes < 0 ? 60 - GetOverspillMinutes(minutes * - 1).Item2 : GetOverspillMinutes(minutes).Item2;
    }

    public int Hours { get; private set; }
    public int Minutes { get; private set; }

    public Clock Add(int minutesToAdd)
    {
        Hours += GetOverspillMinutes(minutesToAdd).Item1;
        if (Minutes + minutesToAdd > 59)
        {
            // Hours = FormatHours(Hours + 1);
            Minutes = (Minutes + GetOverspillMinutes(minutesToAdd).Item2) % 60;
            return this;
        }
        Minutes += minutesToAdd;
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        Hours -= GetOverspillMinutes(minutesToSubtract).Item1;
        if (Minutes - minutesToSubtract < 0)
        {
            Hours = FormatHours(Hours - 1);
            Minutes = 60 - GetOverspillMinutes(minutesToSubtract).Item2;
            return this;
        }
        Minutes -= GetOverspillMinutes(minutesToSubtract).Item2;
        return this;
    }


    public override string ToString()
    {
        return $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";
    }

    public override int GetHashCode()
    {
        return this.Hours.GetHashCode() + this.Minutes.GetHashCode();
    }

    public bool Equals(Clock expected) => Hours == expected.Hours && Minutes == expected.Minutes;

    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Clock p = (Clock)obj;
            return (Hours == p.Hours) && (Minutes == p.Minutes);
        }
    }

    private Tuple<int, int> GetOverspillMinutes(int minutes)
    {
        var overspill = minutes % 60;
        var loops = FormatHours((minutes - overspill) / 60);
        return new Tuple<int, int>(loops, overspill);
    }

    private static int FormatHours(int hoursToAdd)
    {
        if (hoursToAdd < 0) return 24 - ((hoursToAdd * -1) % 24);
        return hoursToAdd >= 24 ? hoursToAdd % 24 : hoursToAdd != 0 ? hoursToAdd : 0;
    }
}