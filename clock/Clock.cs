using System;

public class Clock
{
    public Clock(int hours, int minutes)
    {
        Hours = FormatHours(hours);
        Minutes = FormatMinutes(minutes).Item2;
        if (minutes > 59) Hours += FormatMinutes(minutes).Item1;
    }

    public int Hours { get; set; }
    public int Minutes { get; set; }

    public Clock Add(int minutesToAdd)
    {
        Hours += FormatMinutes(minutesToAdd).Item1;
        Minutes += FormatMinutes(minutesToAdd).Item2;        
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        return $"{Hours.ToString("D2")}:{Minutes.ToString("D2")}";
    }

    private static Tuple<int, int> FormatMinutes(int minutesToAdd)
    {
        if (minutesToAdd > 59)
        {
            double asHours = minutesToAdd / 60;
            double asHoursRounded = Math.Floor(asHours);
            return new Tuple<int, int>
                (FormatHours((int)asHoursRounded), (int)((asHours) - asHoursRounded) * 60);
        }
        return new Tuple<int, int>(0, minutesToAdd);
    }
    private static int FormatHours(int hoursToAdd)
    {
        return hoursToAdd >= 24 ? hoursToAdd % 24 : hoursToAdd;
    }
}