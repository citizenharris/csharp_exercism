using System;
using System.Text.RegularExpressions;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span) 
    {
        if (span < 0 || Regex.IsMatch(digits, @"[^\d]") || span > digits.Length) throw new ArgumentException();
        if (string.IsNullOrEmpty(digits)) return 1;

        long sum = 0;
        for (int i = 0; i < digits.Length; i++)
        {
            if (Char.GetNumericValue(digits[i]) == 0) continue;
            long sequence = 1;
            for (int j = 0; j < span && i + j < digits.Length; j++)
            {
                long digit = (long)Char.GetNumericValue(digits[i + j]);
                if (digit != 0)
                {
                    sequence *= digit;
                } else 
                {
                    sequence = 0;
                }
            }

            if (sum < sequence) sum = sequence;
        }
        return sum;
    }
}