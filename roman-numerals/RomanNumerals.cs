using System.Collections.Generic;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<int, string> _numeralMap = new Dictionary<int, string>() 
    {
        [1000] = "M",
        [900] = "CM",
        [500] = "D",
        [400] = "CD",
        [100] = "C",
        [90] = "XC",
        [50] = "L",
        [40] = "XL",
        [10] = "X",
        [9] = "IX",
        [5] = "V",
        [4] = "IV",
        [1] = "I"
    };
    
    public static string ToRoman(this int value)
    {
        var romanNumeral = "";
        foreach (var numeral in _numeralMap)
        {
            while (value >= numeral.Key) 
            {
                romanNumeral += numeral.Value;
                value -= numeral.Key;
            }
        }
        return romanNumeral;
    }
}