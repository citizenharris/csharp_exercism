using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
    	return year % 4 == 0 ? year % 100 == 0 && year % 400 != 0 : false;
    }
}

// on every year that is evenly divisible by 4
//   except every year that is evenly divisible by 100
//     unless the year is also evenly divisible by 400