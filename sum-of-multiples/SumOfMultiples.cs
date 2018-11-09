using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> values = new HashSet<int>();
        for (int i = 1; i < max; i++)
        {
            foreach (int num in multiples)
            {
                if (num != 0 && i % num == 0)
                {
                    values.Add(i);
                }
            }
        }
        return values.Sum();
    }
}