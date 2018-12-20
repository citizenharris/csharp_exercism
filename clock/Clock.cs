using System;

public class Clock
{
    public Clock(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public int Hours { get; set; }

    public int Minutes { get; set; }

    public Clock Add(int minutesToAdd)
    {
        if (Minutes += minutesToAdd > 60) 
        {
            double asHours = minutesToAdd / 60;
            int asHoursRounded = Math.Floor(asHours);
            Hours += asHoursRounded;
            Minutes += ((asHours) - asHoursRounded) * 60;
        }
        Minutes += minutesToAdd;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}