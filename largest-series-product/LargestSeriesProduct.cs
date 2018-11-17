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
            long sequence = 0;
            for (int j = 0; j < span && i + span <= digits.Length; j++)
            {
                long digit = (long)Char.GetNumericValue(digits[i + j]);
                if (digit != 0 && j == 0) sequence = 1;
                sequence *= digit;
            }

            if (sum < sequence) sum = sequence;
        }
        return span == 0 ? 1 : sum;
    }
}