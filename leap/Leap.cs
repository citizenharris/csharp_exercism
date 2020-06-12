using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        var divisibleBy4 = year % 4 == 0;
        var divisibleBy100 = year % 100 == 0;
        var divisibleBy400 = year % 400 == 0;

        if (divisibleBy4)
            return divisibleBy100 ? divisibleBy400 : true;
        
        return false;
    }
}

// on every year that is evenly divisible by 4
//   except every year that is evenly divisible by 100
//     unless the year is also evenly divisible by 400