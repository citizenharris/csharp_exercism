using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static int[] Factors(long number)
    {
        List<int> factors = new List<int>();
        for (int factor = 2; number > 1; factor++)
        {
            while (number % factor == 0)
            {
                number /= factor;
                factors.Add(factor);
            }
        }
        return factors.ToArray();
    }
}