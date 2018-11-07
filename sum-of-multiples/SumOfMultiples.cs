using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        int sum = 0;
        HashSet<int> values = new HashSet<int>();
        for (int i = 0; i < max; i++)
        {
            if (i >= max) break;
            foreach (int num in multiples)
            {
                if (i == 0 || num == 0) continue;
                if (i % num == 0)
                {
                    values.Add(i);
                }
            }
        }
        foreach (int num in values)
        {
            sum += num;
        }
        return sum;
    }
}