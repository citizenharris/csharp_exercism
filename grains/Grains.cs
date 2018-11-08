using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64) throw new ArgumentOutOfRangeException();
        
        ulong grains = 0;
        for (int i = 0; i < n; i++)
        {
            grains = i == 0 ? 1 : (ulong) (1 * (Math.Pow(2, i)));
        }
        return grains;
  }

    public static ulong Total()
    {
        ulong total = 0;
        for (int i = 1; i <= 64; i++)
        {
            total += Square(i); 
        }
        return total;
    }
}