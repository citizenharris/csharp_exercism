using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class BracketPush
{
    public static bool IsPaired(string input)
    {
        input = Regex.Replace(input, @"[^\{\}\[\]\(\)]", "");
        if (input == "") return true;
        if (input.Length % 2 != 0) return false;

        var left = new List<char>() { '{', '[', '(' };
        var right = new List<char>() { '}', ']', ')' };
        
        for (int k = 0; k < 3; k++)
        {    
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == left[k])
                {
                    var indices = new List<int>();
                    var index = input.IndexOf(right[k], i);
                    if (index == -1) return false;
                    if (indices.Contains(index))
                    {
                        for (int j = i; j < input.Length - i; j++)
                        {
                            if (indices.Contains(j)) continue;
                            if (input.IndexOf(right[k], j) == -1) return false;
                        }
                    }
                    indices.Add(i);
                }
            }
        }

        return true;
    }
}