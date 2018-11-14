using System;
using System.Collections.Generic;
using System.Linq;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (TriangleValidation(side1, side2, side3))
        {
            double[] sides = new double[3] {side1, side2, side3};
            return sides.Distinct().Count() == 3 ? true : false;
        }
        else
        {
            return false;
        }
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (TriangleValidation(side1, side2, side3))
        {
            double[] sides = new double[3] {side1, side2, side3};
            return sides.Distinct().Count() <= 2 ? true : false;
        } 
        else
        {
            return false;
        }
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (TriangleValidation(side1, side2, side3))
        {
            double[] sides = new double[3] {side1, side2, side3};
            return sides.All(x => x == side1) ? true : false;
        } else 
        {
            return false;
        }
    }

  public static bool TriangleValidation(double side1, double side2, double side3)
    {
        if (side1 < 0 || side2 < 0 || side3 < 0) throw new TriangleException();
        if ((!(side1 + side2 >= side3) || !(side2 + side3 >= side1) || !(side1 + side3 >= side2) 
            || (side1 == 0 || side2 == 0 || side3 == 0)))
        {
            return false;
        } else
        {
            return true;
        }
    }
    
}


public class TriangleException : Exception { }